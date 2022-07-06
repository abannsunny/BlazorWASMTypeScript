"use strict";
const fs = require("fs-extra");
const { series, watch } = require("gulp");
const rollup = require('rollup');
const rollupTypescript = require('@rollup/plugin-typescript');
const commonjs = require('@rollup/plugin-commonjs');
const { nodeResolve } = require('@rollup/plugin-node-resolve');

// variables
const outFileName = 'calculator';
const outDir = './wwwroot/js';

function build() {
    fs.emptyDirSync(outDir);
    return rollup
        .rollup({
            external: [
            ],
            input: './wwwroot/Typescript/index.ts',
            plugins: [rollupTypescript({ tsconfig: './tsconfig.json' }),
            nodeResolve({
                browser: true,
                preferBuiltins: false
            }),
            commonjs({})]
        })
        .then(bundle => {

            const outfilePathEnv = `${outDir}/${outFileName}.js`;
            return bundle.write({
                file: outfilePathEnv,
                exports: "named",
                format: "iife",
                name: "Calculator",
                extend: true,
                sourcemap: true
            });
        });
}


function watchTask() {

    watch(["./wwwroot/Typescript/**/*.ts"], series(build));
}

exports.watch = watchTask;
exports.default = series(build);