var gulp = require('gulp');
var sass = require('gulp-sass');
var sourcemaps = require('gulp-sourcemaps');
var rename = require("gulp-rename");
sass.compiler = require('node-sass');
var concat = require("gulp-concat");
var terser = require("gulp-terser");

gulp.task("Compile-Css", function () {
    gulp.src('wwwroot/css/sass/site.scss')
        .pipe(sourcemaps.init())
        .pipe(sass().on('error', errorHandler))
        .pipe(sourcemaps.write('.'))
        .pipe(gulp.dest('wwwroot/css/'));

    return gulp.src('wwwroot/css/sass/site.scss')
        .pipe(sass({ outputStyle: 'compressed' }).on('error', errorHandler))
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest('wwwroot/css/'));
});

gulp.task("Compile-Js", function () {
    gulp.src('wwwroot/js/gf/*.js')
        //.pipe(sourcemaps.init())
        .pipe(concat('site.js'))
        //.pipe(sourcemaps.write('.'))
        .pipe(gulp.dest('wwwroot/js/'));

    return gulp
        .src('wwwroot/js/gf/*.js')
        .pipe(concat('site.min.js'))
        .pipe(terser())
        .pipe(gulp.dest('wwwroot/js/'));
});

gulp.task('default', gulp.series(['Compile-Css', 'Compile-Js']));

gulp.task("Watch-JS", function () {
    gulp.watch('wwwroot/js/sp/*.js', gulp.series(['Compile-Js']));
});

gulp.task("Watch-Css", function () {
    gulp.watch('wwwroot/css/sass/*.scss', gulp.series(['Compile-Css']));
});

// Handle the error
function errorHandler(error) {
    console.log(error.toString());
    this.emit('end');
}