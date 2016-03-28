/*global -$ */
'use strict';

var gulp = require('gulp');
var $ = require('gulp-load-plugins')();
var path = require('path');
var addsrc = require('gulp-add-src');
var order = require("gulp-order");

var paths = {
  css: 'assets/css',
  themes: 'assets/css/styles',
  scripts: 'assets/js'
};

gulp.task('cssmin', function () {
  return gulp.src([paths.css + '/libs/bootstrap.css',
    paths.css + '/animate.css',
    paths.css + '/swiper.css',
    paths.css + '/owl.carousel.css',
    paths.css + '/owl.theme.css',
    paths.css + '/magnific-popup.css',
    paths.css + '/styles/style-blue.css',
    paths.css + '/libs/font-awesome.min.css',
    paths.css + '/media.css'])
    //.pipe($.sourcemaps.init())
    .pipe($.csso())
    .pipe($.concat(paths.css + '/min/mpositive.home.css'))
    //.pipe($.sourcemaps.write('.'))
    .pipe(gulp.dest('.'));
});

gulp.task('scripts', function () {
  return gulp.src(paths.scripts + '/custom.js')
    .pipe($.jshint())
    .pipe($.jshint.reporter('jshint-stylish'))
    .pipe($.if('*.js', $.uglify()))
    .pipe(addsrc([paths.scripts + '/libs/*.js', '!' + paths.scripts + '/libs/modernizr.js']))
    .pipe($.sourcemaps.init())
    .pipe(order([
      'jquery-1.11.2.min.js',
      'bootstrap.min.js',
      'jquery.easing.1.3.js',
      'scrollIt.js',
      'swiper.min.js',
      'owl.carousel.min.js',
      'jquery.magnific-popup.min.js',
      'wow.min.js',
      'jquery.stellar.min.js',
      'jquery.ajaxchimp.min.js',
      'jquery.particleground.min.js',
      'custom.js'
    ], { base: paths.scripts + '/libs/' }))
    .pipe($.concat(paths.scripts + '/min/mpositive.home.js'))
    .pipe($.sourcemaps.write('.'))
    .pipe(gulp.dest('.'));
});

gulp.task('clean', require('del').bind(null, [paths.css]));

gulp.task('build', ['scripts','cssmin'], function () {
  return gulp.src('assets/**/*').pipe($.size({title: 'build', gzip: true}));
});

gulp.task('default', ['clean'], function () {
  gulp.start('build');
});
