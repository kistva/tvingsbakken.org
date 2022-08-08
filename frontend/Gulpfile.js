/*********************************************
 *   GULP SETUP
 *********************************************/
"use strict";
var uuid = "xxxxxxxx-xxxx-Txxx-yxxx-xxxxxxxxxxxx".replace(/[xy]/g, function (c) {
  var d = new Date().getTime();
  var r = (d + Math.random() * 16) % 16 | 0;
  d = Math.floor(d / 16);
  return (c == "x" ? r : (r & 0x7) | 0x8).toString(16);
});

var paths = {
  src: "src/**/*",
  srcCss: "src/css/",
  srcJs: "src/scripts/",
  srcHtml: "src/html/",
  srcImages: "src/img/**/*",
  srcFonts: "src/fonts/**/*.{eot,svg,ttf,woff,woff2,otf}",
  webroot: "../tvingsbakken.org/wwwroot",
  webrootAssets: "../tvingsbakken.org/wwwroot/assets",
  webrootCss: "../tvingsbakken.org/wwwroot/assets/css",
  webrootJs: "../tvingsbakken.org/wwwroot/assets/scripts",
  webrootImages: "../tvingsbakken.org/wwwroot/assets/images",
  webrootFonts: "../tvingsbakken.org/wwwroot/assets/fonts"
};
/*********************************************
 *   REQUIRED
 *********************************************/

var gulp =       require("gulp"),
  clean =        require("gulp-clean"),
  autoprefixer = require("gulp-autoprefixer"),
  include =      require("gulp-include"),
  concat =       require('gulp-concat'),
  minifyCSS =    require("gulp-minify-css"),
  sourcemaps =   require("gulp-sourcemaps"),
  cleanCSS =     require("gulp-clean-css"),
  rename =       require("gulp-rename"),
  fs =           require("fs"),
  sequence =     require("gulp4-run-sequence"),
  uncss =        require('gulp-uncss'),
  csso =         require('gulp-csso'),
  browserSync =  require("browser-sync").create(),
  minify = require('gulp-minify');


function swallowError(error) {
  // If you want details of the error in the console
  return console.log(error.toString());
  this.emit("end");
}


/******************************************
 *   CACHE BUSTING
 ******************************************/

 gulp.task("cachebusting", async function (cb) {
  fs.writeFile(paths.webrootAssets + '/cachebusting.json', '{"id":"' + uuid + '"}', function (err) {
  });
});

/******************************************
 *   CLEAN
 ******************************************/

gulp.task("clean", function () {
  return gulp
  .src(paths.webrootAssets, {read: false, force: true, allowEmpty: true})
  .pipe(clean({force: true}));
});


/******************************************
 *   CREATE FOLDERS
 ******************************************/

gulp.task('createfolders', async function () {

  const folders = [
    'assets',
    'assets/css',
    //'assets/fonts',
    'assets/images',
    'assets/scripts'
  ];

  folders.forEach(dir => {
    if(!fs.existsSync(paths.webroot + '/' + dir)) {
        fs.mkdirSync(paths.webroot  + '/' + dir);
    }   
  });
});


/******************************************
 *   SASS
 ******************************************/

gulp.task("css", async function () {
  var cssSrc = [
    //paths.srcCss+'bootstrap.css',
    //paths.srcCss+'bootstrap-theme.css',
    //paths.srcCss+'overwrite.css',
    //paths.srcCss+'default.css',
    paths.srcCss+'style.css'
  ];

  gulp
    .src(cssSrc, {allowEmpty: true})
    .pipe(include())
    .on("error", swallowError)
    .pipe(minifyCSS())
    .pipe(csso())
    .pipe(concat('css.min.css'))
    .pipe(rename({ suffix: '.' + uuid }))
    .pipe(cleanCSS())
    .pipe(gulp.dest(paths.webrootCss))
});


/******************************************
 *   JS
 ******************************************/

gulp.task("js", async function () {
  var jsSrc = [
//    paths.srcJs+'jquery.js',
//    paths.srcJs+'jquery.easing.1.3.js',
//    paths.srcJs+'bootstrap.min.js',
//    paths.srcJs+'jquery.isotope.min.js',
//    paths.srcJs+'fancybox/jquery.fancybox.pack.js',
//    paths.srcJs+'jquery.scrollTo.js',
//    paths.srcJs+'responsive-slider.js',
//    paths.srcJs+'grid.js',
//    paths.srcJs+'wow.min.js',
    paths.srcJs+'main.js'
  ];



  gulp
    .src(jsSrc, {allowEmpty: true})
    .pipe(include())
    .on("error", swallowError)
    .pipe(concat('js.min.js'))
    .pipe(rename({ suffix: '.' + uuid }))
    .pipe(minify({ ext: { min: '.js' }, noSource: true } ))
    .pipe(gulp.dest(paths.webrootJs))
    .pipe(browserSync.stream());
});


/******************************************
 *   IMAGES
 ******************************************/

gulp.task("images", async function () {
  gulp
    .src(paths.srcImages, {allowEmpty: true})
    .pipe(gulp.dest(paths.webrootImages));
});


/******************************************
 *   FONTS
 ******************************************/
gulp.task("fonts", async function () {
  gulp
    .src(paths.srcFonts, {allowEmpty: true})
    .pipe(gulp.dest(paths.webrootFonts));
});


/******************************************
 *   BUILD
 ******************************************/

gulp.task("build", done => {
  sequence("clean", "createfolders", gulp.parallel("images", "css", "js"), "cachebusting");
  done();
});

