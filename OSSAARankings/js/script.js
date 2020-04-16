function include(scriptUrl) {
    document.write('<script src="' + scriptUrl + '"></script>');
}

function isIE() {
    var myNav = navigator.userAgent.toLowerCase();
    return (myNav.indexOf('msie') != -1) ? parseInt(myNav.split('msie')[1]) : false;
};

/* cookie.JS
 ========================================================*/
include('js/jquery.cookie.js');

/* Easing library
 ========================================================*/
include('js/jquery.easing.1.3.js');

/* Stick up menus
 ========================================================*/
;
(function ($) {
    var o = $('html');
    if (o.hasClass('desktop')) {
        include('js/tmstickup.js');

        $(window).load(function () {
            $('#stuck_container').TMStickUp({})
        });
    }
})(jQuery);

/* ToTop
 ========================================================*/
;
(function ($) {
    var o = $('html');
if (o.hasClass('desktop')) { 
        include('js/jquery.ui.totop.js');

        $(document).ready(function () {
            $().UItoTop({easingType: 'easeOutQuart'});
        });
    } 
})(jQuery);


/* SMOOTH SCROLLIG
 ========================================================*/
;
(function ($) {
    var o = $('html');
    if (o.hasClass('desktop')) {
        include('js/jquery.mousewheel.min.js');
        include('js/jquery.simplr.smoothscroll.min.js');

        $(document).ready(function () {
            $.srSmoothscroll({
                step: 150,
                speed: 800
            });
        });
    }
})(jQuery);

/* Copyright Year
 ========================================================*/
var currentYear = (new Date).getFullYear();
$(document).ready(function () {
    $("#copyright-year").text((new Date).getFullYear());
});

/* Superfish menus
 ========================================================*/
;
(function ($) {
    include('js/superfish.js');

    var o = $('.sf-menu-toggle');
    if (o.length > 0) {
        $(document).ready(function () {
            var n = $('.nav');
            o.click(function () {
                n.toggleClass('active');
                return false;
            });

            $(document).click(function (e) {
                if (n.hasClass('active')) {
                    var target = e.clientX;
                    if (target > (n.width())) {
                        n.removeClass('active');
                    }
                }
            });
        });
    } else {
        include('js/jquery.mobilemenu.js');
    }
})(jQuery);


/* Google Map
 ========================================================*/
;
(function ($) {
    var o = document.getElementById("google-map");
    if (o) {
        include('//maps.googleapis.com/maps/api/js?v=3.exp&amp;sensor=false');

        $(document).ready(function () {

                var styleArray = [
                    {
                        "featureType": "water",
                        "elementType": "geometry",
                        "stylers": [
                            {
                                "color": "#000000"
                            },
                            {
                                "lightness": 17
                            }
                        ]
                    },
                    {
                        "featureType": "landscape",
                        "elementType": "geometry",
                        "stylers": [
                            {
                                "color": "#000000"
                            },
                            {
                                "lightness": 20
                            }
                        ]
                    },
                    {
                        "featureType": "road.highway",
                        "elementType": "geometry.fill",
                        "stylers": [
                            {
                                "color": "#000000"
                            },
                            {
                                "lightness": 17
                            }
                        ]
                    },
                    {
                        "featureType": "road.highway",
                        "elementType": "geometry.stroke",
                        "stylers": [
                            {
                                "color": "#000000"
                            },
                            {
                                "lightness": 29
                            },
                            {
                                "weight": 0.2
                            }
                        ]
                    },
                    {
                        "featureType": "road.arterial",
                        "elementType": "geometry",
                        "stylers": [
                            {
                                "color": "#000000"
                            },
                            {
                                "lightness": 18
                            }
                        ]
                    },
                    {
                        "featureType": "road.local",
                        "elementType": "geometry",
                        "stylers": [
                            {
                                "color": "#000000"
                            },
                            {
                                "lightness": 16
                            }
                        ]
                    },
                    {
                        "featureType": "poi",
                        "elementType": "geometry",
                        "stylers": [
                            {
                                "color": "#000000"
                            },
                            {
                                "lightness": 21
                            }
                        ]
                    },
                    {
                        "elementType": "labels.text.stroke",
                        "stylers": [
                            {
                                "visibility": "on"
                            },
                            {
                                "color": "#000000"
                            },
                            {
                                "lightness": 16
                            }
                        ]
                    },
                    {
                        "elementType": "labels.text.fill",
                        "stylers": [
                            {
                                "saturation": 36
                            },
                            {
                                "color": "#000000"
                            },
                            {
                                "lightness": 40
                            }
                        ]
                    },
                    {
                        "elementType": "labels.icon",
                        "stylers": [
                            {
                                "visibility": "off"
                            }
                        ]
                    },
                    {
                        "featureType": "transit",
                        "elementType": "geometry",
                        "stylers": [
                            {
                                "color": "#000000"
                            },
                            {
                                "lightness": 19
                            }
                        ]
                    },
                    {
                        "featureType": "administrative",
                        "elementType": "geometry.fill",
                        "stylers": [
                            {
                                "color": "#000000"
                            },
                            {
                                "lightness": 20
                            }
                        ]
                    },
                    {
                        "featureType": "administrative",
                        "elementType": "geometry.stroke",
                        "stylers": [
                            {
                                "color": "#000000"
                            },
                            {
                                "lightness": 17
                            },
                            {
                                "weight": 1.2
                            }
                        ]
                    }
                ]


                var coordData = new google.maps.LatLng(parseFloat(36.149652), parseFloat(-95.946121, 15));
                var markCoord1 = new google.maps.LatLng(parseFloat(36.149652), parseFloat(-95.946121, 15));
                var markCoord2 = new google.maps.LatLng(parseFloat(36.149652), parseFloat(-95.946121, 15));
                var markCoord3 = new google.maps.LatLng(parseFloat(36.149652), parseFloat(-95.946121, 15));
                var arrDestinations = [markCoord1, markCoord2, markCoord3];
                var markList = [];

                var mapOptions = {
                    zoom: 14,
                    center: coordData,
                    scrollwheel: false,
                    styles: styleArray
                }

                var markerIcon = {
                    url: "images/gmap_marker.png",
                    size: new google.maps.Size(113, 136),
                    origin: new google.maps.Point(0, 0),
                    anchor: new google.maps.Point(21, 70)
                };
                var activeMarkerIcon = {
                    url: "images/gmap_marker_active.png",
                    size: new google.maps.Size(113, 136),
                    origin: new google.maps.Point(0, 0),
                    anchor: new google.maps.Point(21, 70)
                };

                var content = '<p>4578 Marmora Road, Glasgow D04 89GR <span>800 2345-6789</span></p>';
                var content2 = '<p> 9870 St Vincent Place, Glasgow, DC 45 Fr 45. <span>800 2345-6789</span></p>';

                var contentArray = [content, content2, content];

                function createContent(arr) {
                    var outputArr = [];
                    for (var i = 0; i < arr.length; i++) {
                        var str = '<div class="iw-content">' +
                            contentArray[i] +
                            '</div>';
                        outputArr.push(str);
                    }
                    return outputArr;
                }

                function createListeners(markers,infoArray,length) {
                    var ind = 0;
                    for (var i = 0; i < length; i++) {
                        google.maps.event.addListener(markers[i], 'click', function () {
                            markers[ind].setIcon(markerIcon);
                            ind = this.myIndex;
                            infowindow.setContent(infoArray[this.myIndex]);
                            infowindow.open(map, this);
                            $('.gm-style-iw').parent().parent().addClass("gm-wrapper");
                            this.setIcon(activeMarkerIcon);
                        });
                        google.maps.event.addListener(infowindow, 'closeclick', function () {
                            markList[ind].setIcon(markerIcon);
                        });
                    }
                    return;
                }

                function createMarkers(arrDestinations,infoArray) {
                    var markers = [];
                    var length;
                    if (arrDestinations.length <= infoArray.length){
                        length = arrDestinations.length;
                    }else{
                        length = infoArray.length;
                    }
                    for (var i = 0; i < length; i++) {
                        var marker = new google.maps.Marker({
                            position: arrDestinations[i],
                            map: map,
                            icon: markerIcon,
                            myIndex: i
                        });
                        markers.push(marker);
                    }
                    createListeners(markers,infoArray, length);
                    return markers;
                }



                var infoArray = createContent(contentArray);
                var infowindow = new google.maps.InfoWindow();

                var map = new google.maps.Map(o, mapOptions);

                markList = createMarkers(arrDestinations,infoArray);
            }
        )
        ;
    }
})
(jQuery);

/* WOW
 ========================================================*/
;
(function ($) {
    var o = $('html');

    if ((navigator.userAgent.toLowerCase().indexOf('msie') == -1 ) || (isIE() && isIE() > 9)) {
        if (o.hasClass('desktop')) {
            include('js/wow/wow.js');

            $(document).ready(function () {
                new WOW().init();
            });
        }
    }
})(jQuery);

/* Unveil
 ========================================================*/
;
(function ($) {
    var o = $('.lazy-img img');

    if (o.length > 0) {
        include('js/jquery.unveil.js');

        $(document).ready(function () {
            $(o).unveil(0, function () {
                if (isIE() && isIE() < 9) {
                    $(this).load().addClass("lazy-loaded");
                } else {
                    $(this).load(function () {
                        $(this).addClass("lazy-loaded");
                    })
                }
            });
        });

        $(window).load(function () {
            $(window).trigger('lookup.unveil');
        });

    }
})(jQuery);

/* Orientation tablet fix
 ========================================================*/
$(function () {
    // IPad/IPhone
    var viewportmeta = document.querySelector && document.querySelector('meta[name="viewport"]'),
        ua = navigator.userAgent,

        gestureStart = function () {
            viewportmeta.content = "width=device-width, minimum-scale=0.25, maximum-scale=1.6, initial-scale=1.0";
        },

        scaleFix = function () {
            if (viewportmeta && /iPhone|iPad/.test(ua) && !/Opera Mini/.test(ua)) {
                viewportmeta.content = "width=device-width, minimum-scale=1.0, maximum-scale=1.0";
                document.addEventListener("gesturestart", gestureStart, false);
            }
        };

    scaleFix();
    // Menu Android
    if (window.orientation != undefined) {
        var regM = /ipod|ipad|iphone/gi,
            result = ua.match(regM);
        if (!result) {
            $('.sf-menus li').each(function () {
                if ($(">ul", this)[0]) {
                    $(">a", this).toggle(
                        function () {
                            return false;
                        },
                        function () {
                            window.location.href = $(this).attr("href");
                        }
                    );
                }
            })
        }
    }
});
var ua = navigator.userAgent.toLocaleLowerCase(),
    regV = /ipod|ipad|iphone/gi,
    result = ua.match(regV),
    userScale = "";
if (!result) {
    userScale = ",user-scalable=0"
}
document.write('<meta name="viewport" content="width=device-width,initial-scale=1.0' + userScale + '">')

/* Contact Form
 ========================================================*/
;
(function ($) {
    var o = $('#contact-form');
    if (o.length > 0) {
        include('js/modal.js');
        include('js/TMForm.js');
    }
})(jQuery);


/* Camera
 ========================================================*/
;
(function ($) {
    var o = $('#camera');
    if (o.length > 0) {
        if (!(isIE() && (isIE() > 9))) {
            include('js/jquery.mobile.customized.min.js');
        }

        include('js/camera.js');

        $(document).ready(function () {
            o.camera({
                autoAdvance: true,
                height: '54.6875%',
                minHeight: '700px',
                pagination: false,
                thumbnails: false,
                playPause: false,
                hover: false,
                loader: 'none',
                navigation: true,
                navigationHover: false,
                mobileNavHover: false,
                fx: 'simpleFade'

            })
        });
    }
})(jQuery);

/* FancyBox
 ========================================================*/
;
(function ($) {
    var o = $('.thumb');
    if (o.length > 0) {
        include('js/jquery.fancybox.js');
        include('js/jquery.fancybox-media.js');
        $(document).ready(function () {
            o.fancybox();
        });
    }
})(jQuery);

/* Responsive Tabs
 ========================================================*/
;
(function ($) {
    var o = $('.resp-tabs');
    if (o.length > 0) {
        include('js/jquery.responsive.tabs.js');

        $(document).ready(function () {
            o.easyResponsiveTabs();
        });
    }
})(jQuery);




/* Parallax
 ========================================================*/
;
(function ($) {
    var o = $('.parallax');
    if (o.length > 0 && $('html').hasClass('desktop')) {
        include('js/jquery.rd-parallax.js');
    }
})(jQuery);



