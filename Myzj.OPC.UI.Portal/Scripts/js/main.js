var lookup = {};

var makeTab = function (id, url, title) {

    if (!(url.indexOf("http") === 0 || url.indexOf("https") === 0)) {
        var hostName = window.location.protocol + "//" + window.location.host;
        var prefix = url.substr(0, 1);
        if (prefix === "/") {
            url = hostName + url;
        }
        else {
            url = hostName + "/" + url;
        }
    }

    var tab = App.ExampleTabs.add(new Ext.Panel({
        id: id,
        title: title,
        closable: true,
        hideMode: "offsets",
        iconCls: "#ApplicationForm",
        loader: {
            url: url,
            scripts: true,
            loadMask: true,
            disableCaching: false,
            disableCachingParam: "_"
        }
    }));

    App.ExampleTabs.setActiveTab(tab);

    var node = App.treeMenu.getStore().getNodeById(id),
    expandAndSelect = function (node) {
        App.treeMenu.animate = false;
        node.bubble(function (node) {
            node.expand(false);
        });
        App.treeMenu.getSelectionModel().select(node);
        App.treeMenu.animate = true;
    };

    if (node) {
        expandAndSelect(node);
    } else {
        App.treeMenu.on("load", function (node) {
            node = App.treeMenu.getComponent(id);
            if (node) {
                expandAndSelect(node);
            }
        }, this, { delay: 10, single: true });
    }
};

var loadExample = function (href, id, title) {
    lookup[href] = id;
    var tab = App.ExampleTabs.getComponent(id);
    if (tab) {
        App.ExampleTabs.setActiveTab(tab);
    } else {
        if (Ext.isEmpty(title)) {
            var m = /(\w+)\/$/g.exec(href);
            title = m == null ? "[No name]" : m[1];
        }

        title = title.replace(/<span>&nbsp;<\/span>/g, "");
        title = title.replace(/_/g, " ");

        if (X.isEmpty(href)) {
            xalert('此模块尚未配置连接');
            return;
        }

        makeTab(id, href, title);
    }
};

var onTreeAfterRender = function (tree) {
    var sm = tree.getSelectionModel();

    Ext.create('Ext.util.KeyNav', tree.view.el, {
        enter: function (e) {
            if (sm.hasSelection()) {
                onTreeItemClick(sm.getSelection()[0], e);
            }
        }
    });
};

var onTreeItemClick = function (record, e) {
    if (record.isLeaf()) {
        e.stopEvent();
        loadExample(record.get('href'), record.getId(), record.get('text'));
        return false;
    } else {
        record[record.isExpanded() ? 'collapse' : 'expand']();
    }
};

var change = function (token) {
    if (token) {
        var activeTab;
        var tabs = App.ExampleTabs.items.items;
        for (var i = 0; i < tabs.length; i++) {
            var tab = tabs[i];
            if (tab.loader && tab.loader.url) {
                var tmp = getToken(tab.loader.url);
                if (token.toLowerCase() === tmp.toLowerCase()) {
                    activeTab = tab;
                    break;
                }
            }
        }

        if (!activeTab) {
            App.direct.GetModuleByTag(location.href, {
                success: function (data) {
                    if (data && data.ModuleTag) {
                        loadExample(token, data.ModuleTag, data.ModuleName);
                    }
                }
            });
        }
    } else {
        App.ExampleTabs.setActiveTab(0);
    }
};

var getToken = function (url) {
    var host = window.location.protocol + "//" + window.location.host + "/";
    if (url.indexOf(host) === 0) {
        return url.substr(host.length);
    }
    return url;
};

var addToken = function (el, tab) {
    if (tab.loader && tab.loader.url) {
        var token = getToken(tab.loader.url);
        if (!Ext.isEmpty(token)) {
            Ext.History.add(token);
        }
    } else {
        Ext.History.add("");
    }
};

var keyPress = function (field, e) {
    if (e.keyCode === 13) {
        e.stopEvent();
        return false;
    }
}

var keyUp = function (field, e) {
    if (e.getKey() === 40) {
        return;
    }

    if (e.getKey() === Ext.EventObject.ESC) {
        clearFilter(field);
    } else {
        filter(field);
    }
};

var filter = function (field) {
    var tree = App.treeMenu,
        text = field.getRawValue();

    if (Ext.isEmpty(text, false)) {
        clearFilter(field);
        return;
    }

    field.getTrigger(0).show();

    var re = new RegExp(".*" + text + ".*", "i");

    tree.clearFilter(true);

    tree.filterBy(function (node) {
        var match = re.test(node.data.text.replace(/<span>&nbsp;<\/span>/g, "")),
            pn = node.parentNode;

        if (match && node.isLeaf()) {
            pn.hasMatchNode = true;
        }

        if (pn != null && pn.fixed) {
            if (node.isLeaf() === false) {
                node.fixed = true;
            }
            return true;
        }

        if (node.isLeaf() === false) {
            node.fixed = match;
            return match;
        }

        return (pn != null && pn.fixed) || match;
    }, { expandNodes: false });

    tree.getView().animate = false;
    tree.getRootNode().cascadeBy(function (node) {
        if (node.isRoot()) {
            return;
        }

        if ((node.getDepth() === 1) ||
           (node.getDepth() === 2 && node.hasMatchNode)) {
            node.expand(false);
        }

        delete node.fixed;
        delete node.hasMatchNode;
    }, tree);
    tree.getView().animate = true;
};

var clearFilter = function (field, trigger, index, e) {
    var tree = App.treeMenu;
    field.setValue("");
    field.getTrigger(0).hide();
    tree.clearFilter(true);
    tree.expandAll();
    field.focus(false, 100);
};

var filterSpecialKey = function (field, e) {
    if (e.getKey() == e.DOWN) {
        var n = App.treeMenu.getRootNode().findChildBy(function (node) {
            return node.isLeaf() && !node.data.hidden;
        }, App.treeMenu, true);

        if (n) {
            App.treeMenu.expandPath(n.getPath(), null, null, function () {
                App.treeMenu.getSelectionModel().select(n);
                App.treeMenu.getView().focus();
            });
        }
    }
};

if (window.location.href.indexOf("#") > 0) {
    var directLink = window.location.href.substr(window.location.href.indexOf("#") + 1);

    Ext.onReady(function () {
        Ext.Function.defer(function () {
            if (!Ext.isEmpty(directLink, false)) {
                App.direct.GetModuleByTag(location.href, {
                    success: function (data) {
                        if (data && data.ModuleTag) {
                            loadExample(directLink, data.ModuleTag, data.ModuleName);
                        }
                    }
                });
            }
        }, 100, window);
    }, window);
}