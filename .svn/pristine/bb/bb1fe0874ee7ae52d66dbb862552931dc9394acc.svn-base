function Dictionary() {
    this.items = new Array();
    this.add = function(key, value) {
        this.items[key] = value;
    };
    this.get = function(key) {
        return this.items[key];
    };
    this.remove = function(key) {
        delete this.items[key];
    };
    this.isEmpty = function() {
        return this.items.length == 0;
    };
    this.size = function() {
        return this.items.length;
    };
    this.Containkey = function(key) {
        var tmpItems = this.items;
        for (var p in tmpItems) {
            if (p == key) {
                return true;
            }
        }
        return false;
    };
    this.keys = function() {
        var tmpItems = this.items;
        var k = new Array();
        for (var p in tmpItems) {
            k.push(p);
        }
        return k.join(',');
    }
    this.values = function() {
        var tmpItems = this.items;
        var v = new Array();
        for (var p in tmpItems) {
            v.push(tmpItems[p]);
        }
        return v.join(',');
    };
    this.removeAll = function() {
        var tmpItems = this.items;
        tmpItems.splice(0, tmpItems.length);
    }
}