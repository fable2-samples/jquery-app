# Fable 2.x JQuery app

This is a simple Fable 2.1 app "hello world" jQuery app.
It does not include Elmish or React.

This app aims to demonstrate some basics for how to use and wrap existing JS code and node modules.

If you want to see a Fable app including elmish, check [minimal-elmish-react](https://github.com/fable2-samples/minimal-elmish-react).

More sample apps can be found in [fable2-samples](https://github.com/fable2-samples)

See [NuGet Fable must haves](https://nugetmusthaves.com/Tag/Fable) for a list of great Nuget packages for your app to build on.

Check out [elmish](https://elmish.github.io/elmish/) to add an "elmish" architecture to your app.

## App design

The app simply calls `init` which gets the first `<canvas>` element in the document (`index.html`).

It then sets (mutates) the canvas width and height to a size of `1000` x `800`.
Then it gets the 2D context of the canvas and draws two rectangles, a red and a blue.

## Requirements

- [dotnet SDK](https://www.microsoft.com/net/download/core) 2.1 or higher
- [node.js](https://nodejs.org) with [npm](https://www.npmjs.com/)
- An F# editor like Visual Studio, Visual Studio Code with [Ionide](http://ionide.io/) or [JetBrains Rider](https://www.jetbrains.com/rider/).

### Build/Run infrastructure

#### paket

This app comes with `paket.exe` in the `.paket` folder. You can however also install paket as a global .NET tool to be used across projects.

```bash
$ dotnet tool install --tool-path ".paket" Paket --add-source https://api.nuget.org/v3/index.json --framework netcoreapp2.1
```

#### Mac OSX/Linux

On a Non-Windows OS such as Mac or Linux (also known as \*nix), you will need [mono](https://www.mono-project.com) in order to run `.exe` (Windows executable) files such as paket.exe

## Building and running the app

The following convenience node scripts are included:

- `$ yarn run win:install` (Windows)
- `$ yarn run nix:install` (Mac OSX or Linux)

### Install dependencies

You will need to install both .NET and JS dependencies for your Fable app to compile, build and run.

#### npm JS dependencies

- `npm install` or `yarn install`

#### restore dotnet dependencies

ie. `dotnet restore`

Run `npm run restore` to restore dotnet dependencies

### Use Paket to install nuget dependencies

Use [Paket](https://fsprojects.github.io/Paket/) to install paket depedencies.
`paket.exe` is available in the `.paket` folder

Run `paket` via one of the included npm scripts:

- `npm run paket` (Windows)
- `npm run paket:mono` (Mac/Linux)

#### Mac/Linux

On a Mac or Linux, `paket.exe` needs to be run via [mono](https://www.mono-project.com)
You can manually run a `paket install` as follows:

```bash
$ mono .paket/paket.exe install
Paket version 5.196.0
Resolving packages for group Main:
 - Fable.Core 2.0.3
 - Fable.Import.Browser 1.3.0
 - FSharp.Core 4.6.1
...
```

### Start web development server (hot reload)

- Start Webpack dev server:

`npx webpack-dev-server` or `npm start`

After the first compilation is finished:

- open browser: http://localhost:8080/

Any modification you do to the F# code will be reflected in the web page after saving.

## Project structure

### npm

JS dependencies are declared in `package.json`, while `package-lock.json` is a lock file automatically generated.

### Webpack

[Webpack](https://webpack.js.org) is a JS bundler with extensions, like a static dev server that enables hot reloading on code changes. Fable interacts with Webpack through the `fable-loader`. Configuration for Webpack is defined in the `webpack.config.js` file. Note this sample only includes basic Webpack configuration for development mode, if you want to see a more comprehensive configuration check the [Fable webpack-config-template](https://github.com/fable-compiler/webpack-config-template/blob/master/webpack.config.js).

### F

The sample only contains two F# files: the project (.fsproj) and a source file (.fs) in the `src` folder.

### Web assets

The `index.html` file and other assets like an icon can be found in the `public` folder.
