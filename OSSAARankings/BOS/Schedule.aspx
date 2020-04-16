<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Schedule.aspx.vb" Inherits="OSSAARankings.Schedule" %>

<!DOCTYPE html>
<html class="wide wow-animation" lang="en">
  <head>
    <!-- Site Title-->
    <title>OSSAARankings.com Schedule</title>
    <meta name="format-detection" content="telephone=no">
    <meta name="viewport" content="width=device-width, height=device-height, initial-scale=1.0, user-scalable=1">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta charset="utf-8">
    <link rel="icon" href="images/favicon.ico" type="image/x-icon">
    <!-- Stylesheets-->
    <link rel="stylesheet" type="text/css" href="//fonts.googleapis.com/css?family=Kanit:300,400,500,500i,600,900%7CRoboto:400,900">
    <link rel="stylesheet" href="site/css/bootstrap.css">
    <link rel="stylesheet" href="site/css/fonts.css">
    <link rel="stylesheet" href="site/css/style.css" id="main-styles-link">
    <style>.ie-panel{display: none;background: #212121;padding: 10px 0;box-shadow: 3px 3px 5px 0 rgba(0,0,0,.3);clear: both;text-align:center;position: relative;z-index: 1;} html.ie-10 .ie-panel, html.lt-ie-10 .ie-panel {display: block;}</style>
  </head>
  <body>
    <div class="ie-panel"><a href="http://windows.microsoft.com/en-US/internet-explorer/"><img src="images/ie8-panel/warning_bar_0000_us.jpg" height="42" width="820" alt="You are using an outdated browser. For a faster, safer browsing experience, upgrade for free today."></a></div>
    <div id="preloader">
      <div class="preloader-body">
        <div class="preloader-item"></div>
      </div>
    </div>
    <!-- Page-->
    <div class="page">
      <!-- Page Header-->
      <header class="section page-header rd-navbar-dark">
        <!-- RD Navbar-->
        <div class="rd-navbar-wrap">
          <nav class="rd-navbar rd-navbar-classic" data-layout="rd-navbar-fixed" data-sm-layout="rd-navbar-fixed" data-md-layout="rd-navbar-fixed" data-md-device-layout="rd-navbar-fixed" data-lg-layout="rd-navbar-fixed" data-lg-device-layout="rd-navbar-fixed" data-xl-layout="rd-navbar-static" data-xl-device-layout="rd-navbar-static" data-xxl-layout="rd-navbar-static" data-xxl-device-layout="rd-navbar-static" data-lg-stick-up-offset="166px" data-xl-stick-up-offset="166px" data-xxl-stick-up-offset="166px" data-lg-stick-up="true" data-xl-stick-up="true" data-xxl-stick-up="true">
            <div class="rd-navbar-panel">
              <!-- RD Navbar Toggle-->
              <button class="rd-navbar-toggle" data-rd-navbar-toggle=".rd-navbar-main"><span></span></button>
              <!-- RD Navbar Panel-->
              <div class="rd-navbar-panel-inner container">
                <div class="rd-navbar-collapse rd-navbar-panel-item rd-navbar-panel-item-left">
                  <!-- Owl Carousel-->
                  <div class="owl-carousel-navbar owl-carousel-inline-outer">
                    <div class="owl-inline-nav">
                      <button class="owl-arrow owl-arrow-prev"></button>
                      <button class="owl-arrow owl-arrow-next"></button>
                    </div>
                    <div class="owl-carousel-inline-wrap">
                      <div class="owl-carousel owl-carousel-inline" data-items="1" data-dots="false" data-nav="true" data-autoplay="true" data-autoplay-speed="3200" data-stage-padding="0" data-loop="true" data-margin="10" data-mouse-drag="false" data-touch-drag="false" data-nav-custom=".owl-carousel-navbar">
                        <%= Session("BootstrapScores") %>
                      </div>
                    </div>
                  </div>
                </div>
                <div class="rd-navbar-panel-item rd-navbar-panel-item-right">
                  <ul class="list-inline list-inline-bordered">
                    <li>
                <div class="rd-navbar-collapse-toggle rd-navbar-fixed-element-1" data-rd-navbar-toggle=".rd-navbar-collapse"><span></span></div>
              </div>
            </div>
            <div class="rd-navbar-main">
              <div class="rd-navbar-main-top">
                <div class="rd-navbar-main-container container">
                  <!-- RD Navbar Brand-->
                  <div class="rd-navbar-brand"><a class="brand" href="../landing"><img class="brand-logo " src="site/images/ossaalogoBlack_RedGradient600.png" alt="" width="95" height="126"/></a>
                  </div>
                  <!-- RD Navbar List-->
                  <ul class="rd-navbar-list">
                    <li class="rd-navbar-list-item"><a class="rd-navbar-list-link" href="#"><img src="site/images/1partners-1-inverse-75x42.png" alt="" width="75" height="42"/></a></li>
                    <li class="rd-navbar-list-item"><a class="rd-navbar-list-link" href="#"><img src="site/images/1partners-2-inverse-88x45.png" alt="" width="88" height="45"/></a></li>
                    <li class="rd-navbar-list-item"><a class="rd-navbar-list-link" href="#"><img src="site/images/1partners-3-inverse-79x52.png" alt="" width="79" height="52"/></a></li>
                  </ul>
                  <!-- RD Navbar Search-->
                  <div class="rd-navbar-search">
                  </div>
                </div>
              </div>
              <div class="rd-navbar-main-bottom rd-navbar-darker">
                <div class="rd-navbar-main-container container">
                  <!-- RD Navbar Nav-->
                                    <ul class="rd-navbar-nav">
                                      <li class="rd-nav-item"><a class="rd-nav-link" href="index.html">Home</a>
                                                          <ul class="rd-menu rd-navbar-dropdown">
                                                            <li class="rd-dropdown-item"><a class="rd-dropdown-link" href="#">Niche Templates</a>
                                                                                <ul class="rd-menu rd-navbar-dropdown">
                                                                                  <li class="rd-dropdown-item"><a class="rd-dropdown-link" href="../soccer">Soccer</a>
                                                                                  </li>
                                                                                  <li class="rd-dropdown-item"><a class="rd-dropdown-link" href="../baseball">Baseball</a>
                                                                                  </li>
                                                                                  <li class="rd-dropdown-item"><a class="rd-dropdown-link" href="../basketball">Basketball</a>
                                                                                  </li>
                                                                                  <li class="rd-dropdown-item"><a class="rd-dropdown-link" href="../billiards">Billiards</a>
                                                                                  </li>
                                                                                  <li class="rd-dropdown-item"><a class="rd-dropdown-link" href="../bowling">Bowling</a>
                                                                                  </li>
                                                                                  <li class="rd-dropdown-item"><a class="rd-dropdown-link" href="../rugby">Rugby</a>
                                                                                  </li>
                                                                                </ul>
                                                            </li>
                                                            <li class="rd-dropdown-item"><a class="rd-dropdown-link" href="#">Home Types</a>
                                                                                <ul class="rd-menu rd-navbar-dropdown">
                                                                                  <li class="rd-dropdown-item"><a class="rd-dropdown-link" href="index.html">Home Soccer</a>
                                                                                  </li>
                                                                                  <li class="rd-dropdown-item"><a class="rd-dropdown-link" href="home-baseball.html">Home Baseball</a>
                                                                                  </li>
                                                                                  <li class="rd-dropdown-item"><a class="rd-dropdown-link" href="home-basketball.html">Home Basketball</a>
                                                                                  </li>
                                                                                  <li class="rd-dropdown-item"><a class="rd-dropdown-link" href="home-billiards.html">Home Billiards</a>
                                                                                  </li>
                                                                                  <li class="rd-dropdown-item"><a class="rd-dropdown-link" href="home-bowling.html">Home Bowling</a>
                                                                                  </li>
                                                                                  <li class="rd-dropdown-item"><a class="rd-dropdown-link" href="home-rugby.html">Home Rugby</a>
                                                                                  </li>
                                                                                </ul>
                                                            </li>
                                                          </ul>
                                      </li>
                                    </ul>
                  <div class="rd-navbar-main-element">
                    <ul class="list-inline list-inline-sm">
                      <li><a class="icon icon-xs icon-light fa fa-facebook" href="#"></a></li>
                      <li><a class="icon icon-xs icon-light fa fa-twitter" href="#"></a></li>
                      <li><a class="icon icon-xs icon-light fa fa-instagram" href="#"></a></li>
                    </ul>
                  </div>
                </div>
              </div>
            </div>
          </nav>
        </div>
      </header>
      <!-- Section Breadcrumbs-->
      <section class="section parallax-container breadcrumbs-wrap" data-parallax-img="images/bg-breadcrumbs-1-1920x726.jpg">
        <div class="parallax-content breadcrumbs-custom context-dark">
          <div class="container">
            <h3 class="breadcrumbs-custom-title">SCHEDULES</h3>
          </div>
        </div>
      </section>
      <section class="section section-sm bg-gray-100">    
        <div class="container">
          <div class="row row-50">
            <div class="col-xl-8">
              <!-- Heading Component-->
              <article class="heading-component">
                <div class="heading-component-inner">
                  <h5 class="heading-component-title">Latest games results
                  </h5>
                  <div class="heading-component-aside">
                    <ul class="list-inline list-inline-xs list-inline-middle">
                      <li>
                        <select class="select select-minimal" data-placeholder="Champions League" data-dropdown-class="select-minimal-dropdown" style="min-width: 124px">
                          <%= Session("cboSchools") %>
                            <option value="playoffs 2019" selected="">Playoffs 2019</option>
                          <option value="playoffs 2016">Playoffs 2016</option>
                          <option value="playoffs 2015">Playoffs 2015</option>
                          <option value="playoffs 2014">Playoffs 2014</option>
                          <option value="playoffs 2013">Playoffs 2013</option>
                        </select>
                      </li>
                      <li>
                        <select class="select select-minimal" data-placeholder="2016-2019" data-dropdown-class="select-minimal-dropdown" style="min-width: 150px">
                          <%= Session("cboSports") %>
                          <option value="AcademicBowl" selected="">Academic Bowl</option>
                          <option value="Baseball">Baseball</option>
                          <option value="BaseballFall">Baseball (Fall)</option>
                          <option value="BasketballBoys">Basketball (Boys)</option>
                          <option value="BasketballGirls">Basketball (Girls)</option>
                        </select>
                      </li>
                      <li>
                       <select class="select select-minimal" data-placeholder="2016-2019" data-dropdown-class="select-minimal-dropdown" style="min-width: 110px">
                          <%= Session("cboTasks") %>
                          <option value="2016-2019" selected="">2016-2019</option>
                          <option value="2015-2016">2015-2016</option>
                          <option value="2014-2015">2014-2015</option>
                        </select>
                      </li>
                    </ul>
                  </div>
                </div>
              </article>
              <div class="row row-30">
                <div class="col-md-6">
                  <!-- Game Result Classic-->
                  <article class="game-result game-result-classic">
                    <div class="game-result-main">
                      <div class="game-result-team game-result-team-first">
                        <figure class="game-result-team-figure game-result-team-figure-big"><img src="images/team-sportland-41x55.png" alt="" width="41" height="55"/>
                        </figure>
                        <div class="game-result-team-name">Sportland</div>
                        <div class="game-result-team-country">USA</div>
                      </div>
                      <div class="game-result-middle">
                        <div class="game-result-score-wrap">
                          <div class="game-result-score game-result-team-win">2<span class="game-result-team-label game-result-team-label-top">Win</span>
                          </div>
                          <div class="game-result-score-divider">
                            <svg x="0px" y="0px" width="7px" height="21px" viewbox="0 0 7 21" enable-background="new 0 0 7 21" xml:space="preserve">
                              <g>
                                <circle cx="3.5" cy="3.5" r="3"></circle>
                                <path d="M3.5,1C4.879,1,6,2.122,6,3.5S4.879,6,3.5,6S1,4.878,1,3.5S2.122,1,3.5,1 M3.5,0C1.567,0,0,1.567,0,3.5S1.567,7,3.5,7      S7,5.433,7,3.5S5.433,0,3.5,0L3.5,0z"></path>
                              </g>
                              <g>
                                <circle cx="3.695" cy="17.5" r="3"></circle>
                                <path d="M3.695,15c1.378,0,2.5,1.122,2.5,2.5S5.073,20,3.695,20s-2.5-1.122-2.5-2.5S2.316,15,3.695,15 M3.695,14      c-1.933,0-3.5,1.567-3.5,3.5s1.567,3.5,3.5,3.5s3.5-1.567,3.5-3.5S5.628,14,3.695,14L3.695,14z"></path>
                              </g>
                            </svg>
                          </div>
                          <div class="game-result-score">1
                          </div>
                        </div>
                        <div class="game-results-status">Home</div>
                      </div>
                      <div class="game-result-team game-result-team-second">
                        <figure class="game-result-team-figure game-result-team-figure-big"><img src="images/team-dream-team-50x50.png" alt="" width="50" height="50"/>
                        </figure>
                        <div class="game-result-team-name">Dream Team</div>
                        <div class="game-result-team-country">Spain</div>
                      </div>
                    </div>
                    <div class="game-result-footer">
                      <ul class="game-result-details">
                        <li>New Yorkers Stadium</li>
                        <li>
                          <time datetime="2019-04-14">April 14, 2019</time>
                        </li>
                      </ul>
                    </div>
                  </article>
                </div>
                <div class="col-md-6">
                  <!-- Game Result Classic-->
                  <article class="game-result game-result-classic">
                    <div class="game-result-main">
                      <div class="game-result-team game-result-team-first">
                        <figure class="game-result-team-figure game-result-team-figure-big"><img src="images/team-bavaria-fc-38x50.png" alt="" width="38" height="50"/>
                        </figure>
                        <div class="game-result-team-name">Bavaria FC</div>
                        <div class="game-result-team-country">Germany</div>
                      </div>
                      <div class="game-result-middle">
                        <div class="game-result-score-wrap">
                          <div class="game-result-score">2
                          </div>
                          <div class="game-result-score-divider">
                            <svg x="0px" y="0px" width="7px" height="21px" viewbox="0 0 7 21" enable-background="new 0 0 7 21" xml:space="preserve">
                              <g>
                                <circle cx="3.5" cy="3.5" r="3"></circle>
                                <path d="M3.5,1C4.879,1,6,2.122,6,3.5S4.879,6,3.5,6S1,4.878,1,3.5S2.122,1,3.5,1 M3.5,0C1.567,0,0,1.567,0,3.5S1.567,7,3.5,7      S7,5.433,7,3.5S5.433,0,3.5,0L3.5,0z"></path>
                              </g>
                              <g>
                                <circle cx="3.695" cy="17.5" r="3"></circle>
                                <path d="M3.695,15c1.378,0,2.5,1.122,2.5,2.5S5.073,20,3.695,20s-2.5-1.122-2.5-2.5S2.316,15,3.695,15 M3.695,14      c-1.933,0-3.5,1.567-3.5,3.5s1.567,3.5,3.5,3.5s3.5-1.567,3.5-3.5S5.628,14,3.695,14L3.695,14z"></path>
                              </g>
                            </svg>
                          </div>
                          <div class="game-result-score game-result-team-win">3<span class="game-result-team-label game-result-team-label-top">Win</span>
                          </div>
                        </div>
                        <div class="game-results-status">Away</div>
                      </div>
                      <div class="game-result-team game-result-team-second">
                        <figure class="game-result-team-figure game-result-team-figure-big"><img src="images/team-real-madrid-38x50.png" alt="" width="38" height="50"/>
                        </figure>
                        <div class="game-result-team-name">Real Madrid</div>
                        <div class="game-result-team-country">Spain</div>
                      </div>
                    </div>
                    <div class="game-result-footer">
                      <ul class="game-result-details">
                        <li>Bavaria Stadium</li>
                        <li>
                          <time datetime="2019-04-14">April 14, 2019</time>
                        </li>
                      </ul>
                    </div>
                  </article>
                </div>
                <div class="col-md-6">
                  <!-- Game Result Classic-->
                  <article class="game-result game-result-classic">
                    <div class="game-result-main">
                      <div class="game-result-team game-result-team-first">
                        <figure class="game-result-team-figure game-result-team-figure-big"><img src="images/team-sportland-41x55.png" alt="" width="41" height="55"/>
                        </figure>
                        <div class="game-result-team-name">Sportland</div>
                        <div class="game-result-team-country">USA</div>
                      </div>
                      <div class="game-result-middle">
                        <div class="game-result-score-wrap">
                          <div class="game-result-score game-result-team-win">4<span class="game-result-team-label game-result-team-label-top">Win</span>
                          </div>
                          <div class="game-result-score-divider">
                            <svg x="0px" y="0px" width="7px" height="21px" viewbox="0 0 7 21" enable-background="new 0 0 7 21" xml:space="preserve">
                              <g>
                                <circle cx="3.5" cy="3.5" r="3"></circle>
                                <path d="M3.5,1C4.879,1,6,2.122,6,3.5S4.879,6,3.5,6S1,4.878,1,3.5S2.122,1,3.5,1 M3.5,0C1.567,0,0,1.567,0,3.5S1.567,7,3.5,7      S7,5.433,7,3.5S5.433,0,3.5,0L3.5,0z"></path>
                              </g>
                              <g>
                                <circle cx="3.695" cy="17.5" r="3"></circle>
                                <path d="M3.695,15c1.378,0,2.5,1.122,2.5,2.5S5.073,20,3.695,20s-2.5-1.122-2.5-2.5S2.316,15,3.695,15 M3.695,14      c-1.933,0-3.5,1.567-3.5,3.5s1.567,3.5,3.5,3.5s3.5-1.567,3.5-3.5S5.628,14,3.695,14L3.695,14z"></path>
                              </g>
                            </svg>
                          </div>
                          <div class="game-result-score">1
                          </div>
                        </div>
                        <div class="game-results-status">Home</div>
                      </div>
                      <div class="game-result-team game-result-team-second">
                        <figure class="game-result-team-figure game-result-team-figure-big"><img src="images/team-celta-vigo-45x50.png" alt="" width="45" height="50"/>
                        </figure>
                        <div class="game-result-team-name">Celta Vigo</div>
                        <div class="game-result-team-country">Italy</div>
                      </div>
                    </div>
                    <div class="game-result-footer">
                      <ul class="game-result-details">
                        <li>New Yorkers Stadium</li>
                        <li>
                          <time datetime="2019-04-14">April 14, 2019</time>
                        </li>
                      </ul>
                    </div>
                  </article>
                </div>
                <div class="col-md-6">
                  <!-- Game Result Classic-->
                  <article class="game-result game-result-classic">
                    <div class="game-result-main">
                      <div class="game-result-team game-result-team-first">
                        <figure class="game-result-team-figure game-result-team-figure-big"><img src="images/team-sportland-41x55.png" alt="" width="41" height="55"/>
                        </figure>
                        <div class="game-result-team-name">sportland</div>
                        <div class="game-result-team-country">USA</div>
                      </div>
                      <div class="game-result-middle">
                        <div class="game-result-score-wrap">
                          <div class="game-result-score game-result-team-win">2<span class="game-result-team-label game-result-team-label-top">Win</span>
                          </div>
                          <div class="game-result-score-divider">
                            <svg x="0px" y="0px" width="7px" height="21px" viewbox="0 0 7 21" enable-background="new 0 0 7 21" xml:space="preserve">
                              <g>
                                <circle cx="3.5" cy="3.5" r="3"></circle>
                                <path d="M3.5,1C4.879,1,6,2.122,6,3.5S4.879,6,3.5,6S1,4.878,1,3.5S2.122,1,3.5,1 M3.5,0C1.567,0,0,1.567,0,3.5S1.567,7,3.5,7      S7,5.433,7,3.5S5.433,0,3.5,0L3.5,0z"></path>
                              </g>
                              <g>
                                <circle cx="3.695" cy="17.5" r="3"></circle>
                                <path d="M3.695,15c1.378,0,2.5,1.122,2.5,2.5S5.073,20,3.695,20s-2.5-1.122-2.5-2.5S2.316,15,3.695,15 M3.695,14      c-1.933,0-3.5,1.567-3.5,3.5s1.567,3.5,3.5,3.5s3.5-1.567,3.5-3.5S5.628,14,3.695,14L3.695,14z"></path>
                              </g>
                            </svg>
                          </div>
                          <div class="game-result-score">1
                          </div>
                        </div>
                        <div class="game-results-status">Home</div>
                      </div>
                      <div class="game-result-team game-result-team-second">
                        <figure class="game-result-team-figure game-result-team-figure-big"><img src="images/team-barcelona-45x55.png" alt="" width="45" height="55"/>
                        </figure>
                        <div class="game-result-team-name">Barcelona</div>
                        <div class="game-result-team-country">Spain</div>
                      </div>
                    </div>
                    <div class="game-result-footer">
                      <ul class="game-result-details">
                        <li>New Yorkers Stadium</li>
                        <li>
                          <time datetime="2019-04-14">April 14, 2019</time>
                        </li>
                      </ul>
                    </div>
                  </article>
                </div>
              </div>
            </div>
            <div class="col-xl-4">
              <!-- Heading Component-->
              <article class="heading-component">
                <div class="heading-component-inner">
                  <h5 class="heading-component-title">Sponsors
                  </h5>
                </div>
              <div class="tabs-custom tabs-horizontal tabs-modern" id="tabs-modern">
                  <ul class="nav nav-tabs">
                      <li class="nav-item" role="presentation"><a class="nav-link active" href="#tabs-modern-1" data-toggle="tab">Schedule</a></li>
                      <li class="nav-item" role="presentation"><a class="nav-link" href="#tabs-modern-2" data-toggle="tab">Roster</a></li>
                      <li class="nav-item" role="presentation"><a class="nav-link" href="#tabs-modern-3" data-toggle="tab">Enter Rankings</a></li>
                      <li class="nav-item" role="presentation"><a class="nav-link" href="#tabs-modern-4" data-toggle="tab">Personal Info</a></li>
                      <li class="nav-item" role="presentation"><a class="nav-link" href="#tabs-modern-5" data-toggle="tab">Contact Us</a></li>
                      <li class="nav-item" role="presentation"><a class="nav-link" href="#tabs-modern-6" data-toggle="tab">On-Line Entry Forms</a></li>
                  </ul>
                <div class="tab-content">
                  <div class="tab-pane fade show active" id="tabs-modern-1">
                    <article class="post-classic">
                        <div class="post-classic-aside"><a class="post-classic-figure" href="blog-post.html"><img src="images/blog-element-5-94x94.jpg" alt="" width="94" height="94"/></a></div>
                            <div class="post-classic-main">
                                <p class="post-classic-title"><a href="blog-post.html">Alvaro Morata proving his worth at Chelsea</a></p>
                                <div class="post-classic-time"><span class="icon mdi mdi-clock"></span>
                                <time datetime="2019">April 1, 2019
                                          <!-- Tabs Modern with Post Classic-->
                                </time>
                            </div>
                        </div>
                    </article>
                  </div>
                  <div class="tab-pane fade show active" id="tabs-modern-2">
                    <article class="post-classic">
                        <div class="post-classic-aside"><a class="post-classic-figure" href="blog-post.html"><img src="images/blog-element-5-94x94.jpg" alt="" width="94" height="94"/></a></div>
                            <div class="post-classic-main">
                                <p class="post-classic-title"><a href="blog-post.html">Alvaro Morata proving his worth at Chelsea</a></p>
                                <div class="post-classic-time"><span class="icon mdi mdi-clock"></span>
                                <time datetime="2019">April 2, 2019
                                          <!-- Tabs Modern with Post Classic-->
                                </time>
                            </div>
                        </div>
                    </article>
                  </div>
                  <div class="tab-pane fade show active" id="tabs-modern-3">
                    <article class="post-classic">
                        <div class="post-classic-aside"><a class="post-classic-figure" href="blog-post.html"><img src="images/blog-element-5-94x94.jpg" alt="" width="94" height="94"/></a></div>
                            <div class="post-classic-main">
                                <p class="post-classic-title"><a href="blog-post.html">Alvaro Morata proving his worth at Chelsea</a></p>
                                <div class="post-classic-time"><span class="icon mdi mdi-clock"></span>
                                <time datetime="2019">April 3, 2019
                                          <!-- Tabs Modern with Post Classic-->
                                </time>
                            </div>
                        </div>
                    </article>
                  </div>
                  <div class="tab-pane fade show active" id="tabs-modern-4">
                    <article class="post-classic">
                        <div class="post-classic-aside"><a class="post-classic-figure" href="blog-post.html"><img src="images/blog-element-5-94x94.jpg" alt="" width="94" height="94"/></a></div>
                            <div class="post-classic-main">
                                <p class="post-classic-title"><a href="blog-post.html">Alvaro Morata proving his worth at Chelsea</a></p>
                                <div class="post-classic-time"><span class="icon mdi mdi-clock"></span>
                                <time datetime="2019">April 4, 2019
                                          <!-- Tabs Modern with Post Classic-->
                                </time>
                            </div>
                        </div>
                    </article>
                  </div>
                  <div class="tab-pane fade show active" id="tabs-modern-5">
                    <article class="post-classic">
                        <div class="post-classic-aside"><a class="post-classic-figure" href="blog-post.html"><img src="images/blog-element-5-94x94.jpg" alt="" width="94" height="94"/></a></div>
                            <div class="post-classic-main">
                                <p class="post-classic-title"><a href="blog-post.html">Alvaro Morata proving his worth at Chelsea</a></p>
                                <div class="post-classic-time"><span class="icon mdi mdi-clock"></span>
                                <time datetime="2019">April 5, 2019
                                          <!-- Tabs Modern with Post Classic-->
                                </time>
                            </div>
                        </div>
                    </article>
                  </div>
                  <div class="tab-pane fade show active" id="tabs-modern-6">
                    <article class="post-classic">
                        <div class="post-classic-aside"><a class="post-classic-figure" href="blog-post.html"><img src="images/blog-element-5-94x94.jpg" alt="" width="94" height="94"/></a></div>
                            <div class="post-classic-main">
                                <p class="post-classic-title"><a href="blog-post.html">Alvaro Morata proving his worth at Chelsea</a></p>
                                <div class="post-classic-time"><span class="icon mdi mdi-clock"></span>
                                <time datetime="2019">April 6, 2019
                                          <!-- Tabs Modern with Post Classic-->
                                </time>
                            </div>
                        </div>
                    </article>
                  </div>
                </div>
            </div>
              </article>
              </div>
          </div>
        </div>
      </section>

      <!-- Page Footer-->
      <footer class="section footer-classic footer-classic-dark context-dark">
        <div class="footer-classic-main">
          <div class="container">
            <div class="row row-50">
              <div class="col-lg-5 text-center text-sm-left">
                <ul class="list-inline list-inline-bordered list-inline-bordered-lg">
                  <li>
                    <div class="unit unit-horizontal unit-middle">
                      <div class="unit-left">
                        <svg class="svg-color-primary svg-sizing-35" x="0px" y="0px" width="72px" height="72px" viewbox="0 0 72 72">
                          <path d="M36.002,0c-0.41,0-0.701,0.184-0.931,0.332c-0.23,0.149-0.4,0.303-0.4,0.303l-9.251,8.18H11.58 c-1.236,0-1.99,0.702-2.318,1.358c-0.329,0.658-0.326,1.3-0.326,1.3v11.928l-8.962,7.936V66c0,0.015-0.038,1.479,0.694,2.972 C1.402,70.471,3.006,72,5.973,72h30.03h30.022c2.967,0,4.571-1.53,5.306-3.028c0.736-1.499,0.702-2.985,0.702-2.985V31.338 l-8.964-7.936V11.475c0,0,0.004-0.643-0.324-1.3c-0.329-0.658-1.092-1.358-2.328-1.358H46.575l-9.251-8.18 c0,0-0.161-0.154-0.391-0.303C36.703,0.184,36.412,0,36.002,0z M36.002,3.325c0.49,0,0.665,0.184,0.665,0.184l6,5.306h-6.665 h-6.665l6-5.306C35.337,3.51,35.512,3.325,36.002,3.325z M12.081,11.977h23.92H59.92v9.754v2.121v14.816L48.511,48.762 l-10.078-8.911c0,0-0.307-0.279-0.747-0.548s-1.022-0.562-1.684-0.562c-0.662,0-1.245,0.292-1.686,0.562 c-0.439,0.268-0.747,0.548-0.747,0.548l-10.078,8.911L12.082,38.668V23.852v-2.121v-9.754H12.081z M8.934,26.867v9.015 l-5.091-4.507L8.934,26.867z M63.068,26.867l5.091,4.509l-5.091,4.507V26.867z M69.031,34.44v31.559 c0,0.328-0.103,0.52-0.162,0.771L50.685,50.684L69.031,34.44z M2.971,34.448l18.348,16.235L3.133,66.77 c-0.059-0.251-0.162-0.439-0.162-0.769C2.971,66.001,2.971,34.448,2.971,34.448z M36.002,41.956c0.264,0,0.437,0.057,0.546,0.104 c0.108,0.047,0.119,0.059,0.119,0.059l30.147,26.675c-0.3,0.054-0.79,0.207-0.79,0.207H36.002H5.98H5.972 c-0.003,0-0.488-0.154-0.784-0.207l30.149-26.675c0,0,0.002-0.011,0.109-0.059C35.555,42.013,35.738,41.956,36.002,41.956z"></path>
                        </svg>
                      </div>
                      <div class="unit-body">
                        <h6>Contact Us</h6><a class="link" href="mailto:#">cwilfong@ossaa.com</a>
                      </div>
                    </div>
                  </li>
                </ul>
              </div>
            </div>
          </div>
        </div>
        <div class="footer-classic-aside footer-classic-darken">
          <div class="container">
            <div class="layout-justify">
              <!-- Rights-->
              <p class="rights"><span>Sportland</span><span>&nbsp;&copy;&nbsp;</span><span class="copyright-year"></span><span>.&nbsp;</span><a class="link-underline" href="www.ossaa.com">Oklahoma Secondary School Activities Association</a></p>
              <nav class="nav-minimal">
              </nav>
            </div>
          </div>
        </div>
      </footer>
    </div>
    <!-- Global Mailform Output-->
    <div class="snackbars" id="form-output-global"></div>
    <!-- Javascript-->
    <script src="site/js/core.min.js"></script>
    <script src="site/js/script.js"></script>
  </body>
</html>
