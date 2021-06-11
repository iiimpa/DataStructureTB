(function () {
    //改浏览器状态为可视
    Object.defineProperty(document, 'visibilityState', { configurable: true, get: function () { return 'visible'; } });
    Object.defineProperty(document, 'hidden', { value: false });
    Object.defineProperty(document, 'webkitVisibilityState', { value: 'visible' });

    //硬件平台
    Object.defineProperty(navigator, 'platform', { get: function () { return apiInject.finger.platform; } });//方法2

    //deviceMemory
    Object.defineProperty(navigator, 'deviceMemory', {
        get: () => {
            return apiInject.finger.deviceMemory
        }
    });


    //hardwareConcurrency
    Object.defineProperty(navigator, 'hardwareConcurrency', {
        get: () => {
            return apiInject.finger.hardwareConcurrency
        }
    })

    //vendor
    Object.defineProperty(navigator, 'vendor', {
        get: () => {
            return apiInject.finger.vendors
        }
    })

    // 分辨率
    var myScreen = {};

    // 获取所有screen属性
    for (var i in screen) {
        myScreen[i] = screen[i];
    }
    screen = myScreen;
    screen.width = apiInject.finger.screen.split('x')[0];
    screen.height = apiInject.finger.screen.split('x')[1];
    screen.availHeight = apiInject.finger.screen.split('x')[1];
    screen.availWidth = apiInject.finger.screen.split('x')[0];

    // 自动化软件控制
    Object.defineProperties(navigator, {
        webdriver: {
            get: () => false
        }
    })

    window.navigator.chrome = {
        runtime: {},
    };

    // 插件数量
    Object.defineProperty(navigator, 'plugins', {
        get: () => [1, 2, 3, 4, 5],
    });

    const toBlob = HTMLCanvasElement.prototype.toBlob;
    const toDataURL = HTMLCanvasElement.prototype.toDataURL;
    const getImageData = CanvasRenderingContext2D.prototype.getImageData;

    // 噪声
    var noisify = function (canvas, context) {
        const shift = {
            'r': apiInject.finger.random_1, //随机数1
            'g': apiInject.finger.random_2, //随机数2
            'b': apiInject.finger.random_3,   //随机数3
            'a': apiInject.finger.random_4  //随机数4
        };
        const width = canvas.width,
            height = canvas.height;
        const imageData = getImageData.apply(context, [0, 0, width, height]);
        for (let i = 0; i < height; i++) {
            for (let j = 0; j < width; j++) {
                const n = ((i * (width * 4)) + (j * 4));
                imageData.data[n + 0] = imageData.data[n + 0] + shift.r;
                imageData.data[n + 1] = imageData.data[n + 1] + shift.g;
                imageData.data[n + 2] = imageData.data[n + 2] + shift.b;
                imageData.data[n + 3] = imageData.data[n + 3] + shift.a;
            }
        }
        window.top.postMessage('canvas-fingerprint-defender-alert', '*');
        context.putImageData(imageData, 0, 0);
    };

    Object.defineProperty(HTMLCanvasElement.prototype, 'toBlob', {
        'value': function () {
            noisify(this, this.getContext('2d'));
            return toBlob.apply(this, arguments);
        }
    });

    Object.defineProperty(HTMLCanvasElement.prototype, 'toDataURL', {
        'value': function () {
            noisify(this, this.getContext('2d'));
            return toDataURL.apply(this, arguments);
        }
    });

    Object.defineProperty(CanvasRenderingContext2D.prototype, 'getImageData', {
        'value': function () {
            noisify(this.canvas, this);
            return getImageData.apply(this, arguments);
        }
    });
    document.documentElement.dataset.cbscriptallow = true;

    //canvas
    var config = {
        'random': {
            'value': function () { return apiInject.finger.random_14 },
            'item': function (e) {
                var rand = e.length * config.random.value();
                return e[Math.floor(rand)];
            },
            'array': function (e) {
                var rand = config.random.item(e);
                return new Int32Array([rand, rand]);
            },
            'items': function (e, n) {
                var length = e.length;
                var result = new Array(n);
                var taken = new Array(length);
                if (n > length) n = length;
                //
                while (n--) {
                    var i = Math.floor(config.random.value() * length);
                    result[n] = e[i in taken ? taken[i] : i];
                    taken[i] = --length in taken ? taken[length] : length;
                }
                //
                return result;
            }
        },
        'spoof': {
            'webgl': {
                'buffer': function (target) {
                    const bufferData = target.prototype.bufferData;
                    Object.defineProperty(target.prototype, 'bufferData', {
                        'value': function () {
                            var index = Math.floor(config.random.value() * 10);
                            var noise = 0.1 * config.random.value() * arguments[1][index];
                            arguments[1][index] = arguments[1][index] + noise;
                            window.top.postMessage('webgl-fingerprint-defender-alert', '*');
                            //
                            return bufferData.apply(this, arguments);
                        }
                    });
                },
                'parameter': function (target) {
                    const getParameter = target.prototype.getParameter;
                    Object.defineProperty(target.prototype, 'getParameter', {
                        'value': function () {
                            var float32array = new Float32Array([1, 8192]);
                            window.top.postMessage('webgl-fingerprint-defender-alert', '*');
                            //
                            if (arguments[0] === 3415) return 0;
                            else if (arguments[0] === 3414) return 24;
                            else if (arguments[0] === 37445) return apiInject.finger.vendors;
                            else if (arguments[0] === 37446) return 'ANGLE ('+apiInject.finger.gpu+' '+apiInject.finger.model+' vs_3_0 ps_1_0)';
                            else if (arguments[0] === 35661) return config.random.items([128, 192, 256]);
                            else if (arguments[0] === 3386) return config.random.array([8192, 16384, 32768]);
                            else if (arguments[0] === 36349 || arguments[0] === 36347) return config.random.item([4096, 8192]);
                            else if (arguments[0] === 34047 || arguments[0] === 34921) return config.random.items([2, 4, 8, 16]);
                            else if (arguments[0] === 7937 || arguments[0] === 33901 || arguments[0] === 33902) return float32array;
                            else if (arguments[0] === 34930 || arguments[0] === 36348 || arguments[0] === 35660) return config.random.item([16, 32, 64]);
                            else if (arguments[0] === 34076 || arguments[0] === 34024 || arguments[0] === 3379) return config.random.item([16384, 32768]);
                            else if (arguments[0] === 3413 || arguments[0] === 3412 || arguments[0] === 3411 || arguments[0] === 3410 || arguments[0] === 34852) return config.random.item([2, 4, 8, 16]);
                            else return config.random.item([0, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096]);
                            //
                            return getParameter.apply(this, arguments);
                        }
                    });
                }
            }
        }
    };

    //
    config.spoof.webgl.buffer(WebGLRenderingContext);
    config.spoof.webgl.buffer(WebGL2RenderingContext);
    config.spoof.webgl.parameter(WebGLRenderingContext);
    config.spoof.webgl.parameter(WebGL2RenderingContext);

    //
    document.documentElement.dataset.wgscriptallow = true;

    //webgl
    const context = {
        'BUFFER': null,
        'getChannelData': function (e) {
            const getChannelData = e.prototype.getChannelData;
            Object.defineProperty(e.prototype, 'getChannelData', {
                'value': function () {
                    const results_1 = getChannelData.apply(this, arguments);
                    if (context.BUFFER !== results_1) {
                        context.BUFFER = results_1;
                        window.top.postMessage('audiocontext-fingerprint-defender-alert', '*');
                        for (var i = 0; i < results_1.length; i += 100) {
                            let index = Math.floor(apiInject.finger.random_5 * i);
                            results_1[index] = results_1[index] + apiInject.finger.random_6 * 0.0000001;
                        }
                    }
                    //
                    return results_1;
                }
            });
        },
        'createAnalyser': function (e) {
            const createAnalyser = e.prototype.__proto__.createAnalyser;
            Object.defineProperty(e.prototype.__proto__, 'createAnalyser', {
                'value': function () {
                    const results_2 = createAnalyser.apply(this, arguments);
                    const getFloatFrequencyData = results_2.__proto__.getFloatFrequencyData;
                    Object.defineProperty(results_2.__proto__, 'getFloatFrequencyData', {
                        'value': function () {
                            window.top.postMessage('audiocontext-fingerprint-defender-alert', '*');
                            const results_3 = getFloatFrequencyData.apply(this, arguments);
                            for (var i = 0; i < arguments[0].length; i += 100) {
                                let index = Math.floor(apiInject.finger.random_7 * i); //随机数7
                                arguments[0][index] = arguments[0][index] + apiInject.finger.random_8
                            }
                            //
                            return results_3;
                        }
                    });
                    //
                    return results_2;
                }
            });
        }
    };
    //
    context.getChannelData(AudioBuffer);
    context.createAnalyser(AudioContext);
    context.getChannelData(OfflineAudioContext);
    context.createAnalyser(OfflineAudioContext);
    document.documentElement.dataset.acxscriptallow = true;

    ////音频
    //var rand = {
    //    'noise': function () {
    //        var SIGN = apiInject.finger.random_9 < apiInject.finger.random_10 ? -1 : 1;
    //        return Math.floor(apiInject.finger.random_11 + SIGN * apiInject.finger.random_12);
    //    },
    //    'sign': function () {
    //        const tmp = [-1, -1, -1, -1, -1, -1, +1, -1, -1, -1];
    //        const index = Math.floor(apiInject.finger.random_13 * tmp.length);
    //        return tmp[index];
    //    }
    //};
    ////
    //Object.defineProperty(HTMLElement.prototype, 'offsetHeight', {
    //    get() {
    //        const height = Math.floor(this.getBoundingClientRect().height);
    //        const valid = height && rand.sign() === 1;
    //        const result = valid ? height + rand.noise() : height;
    //        //
    //        if (valid && result !== height) {
    //            window.top.postMessage('font-fingerprint-defender-alert', '*');
    //        }
    //        //
    //        return result;
    //    }
    //});
    ////
    //Object.defineProperty(HTMLElement.prototype, 'offsetWidth', {
    //    get() {
    //        const width = Math.floor(this.getBoundingClientRect().width);
    //        const valid = width && rand.sign() === 1;
    //        const result = valid ? width + rand.noise() : width;
    //        //
    //        if (valid && result !== width) {
    //            window.top.postMessage('font-fingerprint-defender-alert', '*');
    //        }
    //        //
    //        return result;
    //    }
    //});
})()