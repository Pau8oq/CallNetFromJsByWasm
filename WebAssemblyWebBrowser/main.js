// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

import { dotnet } from './dotnet.js'

const { setModuleImports, getAssemblyExports, getConfig } = await dotnet
    .withDiagnosticTracing(false)
    .withApplicationArgumentsFromQuery()
    .create();

setModuleImports('main.js', {
    window: {
        location: {
            href: () => globalThis.window.location.href
        }
    }
});

const config = getConfig();
const exports = await getAssemblyExports(config.mainAssemblyName);

document.getElementById('get-os').addEventListener('click', () => {
    let os = exports.MyClass.GetOs();
    document.getElementById('out').innerHTML = os;
});

document.getElementById('get-rnd').addEventListener('click', () => {
    let rnd = exports.MyClass.GetRnd();
    document.getElementById('out').innerHTML = rnd;
});

document.getElementById('get-img-sharp').addEventListener('click', () => {
    let imgSrc = exports.MyClass.GetImageFromImageSharp();

    var image = new Image();
    image.src = imgSrc;

    document.getElementById('out').innerHTML = '';
    document.getElementById('out').appendChild(image);
});


await dotnet.run();