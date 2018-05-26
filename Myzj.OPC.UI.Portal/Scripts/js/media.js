var players = new Dictionary();
var ctrlers = new Dictionary();

function playAudio(f, i, c) {
    var audioPlayer;
    var url = Ext.String.format('{0}/upload/voice/{1}?id={2}', wechatRoot, f, i);
    if (!players.Containkey(url)) {
        audioPlayer = new Audio5js({
            id: url,
            ready: audioReady
        });
        audioPlayer.load(url);
        audioPlayer.play();
        players.add(url, audioPlayer);
        c.title = '暂停';
        c.src = '/resources/audio5js/icon/play.png';
        ctrlers.add(url, c);
    }
    else {//取出播放器
        audioPlayer = players.get(url);
        audioPlayer.pause();
        players.remove(url);
        c.src = '/resources/audio5js/icon/stop.png';
        c.title = '播放';
    }
}

var audioReady = function () {
    //this points to the Audio5js instance
    //this.on('play', function () { console.log(this.id); }, this);
    //this.on('pause', function () { console.log(this.id); }, this);
    this.on('ended', function () {
        var url = this.settings.id;
        players.get(url).pause();
        players.remove(url);
        var ctrl = ctrlers.get(url);
        ctrl.title = '播放';
        ctrl.src = '/resources/audio5js/icon/stop.png';
        ctrlers.remove(url);
    }, this);

    // timeupdate event passes audio duration and position to callback
    //this.on('timeupdate', function (position, duration) {
    //    console.log(position, duration);
    //}, this);

    // progress event passes load_percent to callback
    //this.on('progress', function (load_percent) {
    //    console.log(load_percent);
    //}, this);

    //error event passes error object to callback
    //this.on('error', function (error) {
    //    console.log(error.message);
    //}, this);
}

function playVideo(a) {
    window.showModalDialog('Video.aspx?VideoName=' + a, null, "dialogHeight=450px;dialogWidth=617px;center=1;resizable=0;");
}

function buildVoiceLink(n, i) {
    var ctl = X.String.format('<img style="width: 24px; height: 24px; cursor: pointer;" title="播放" src="/resources/audio5js/icon/stop.png" onclick="playAudio(\'{0}\',\'{1}\',this);" />', n, i);
    return ctl;
}

function buildVideoLink(n) {
    var ctl = X.String.format('<img style="width: 24px; height: 24px; cursor: pointer;" title="播放" src="/resources/video/video.png" onclick="playVideo(\'{0}\')" />', n);
    return ctl;
}