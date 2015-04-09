# IronJint

## Summary

**IronJint** is a very thin wrapper of "**[Jint](https://github.com/sebastienros/jint)**" - one of the popular JavaScript interpreter worked on .NET Framework that supported ECMAScript5 - for adapt Jint to `Microsoft.Scripting.Runtime.LanguageContext` interface.

Total count of all source codes lines is only **91 lines** :)

## How to use

1) Install IronJint via NuGet package repository.

```
PM> Install-Package IronJint -Pre
```

2) Configure application configuration file(.config)

```xml
<configuration>
  <configSections>
    <section
        name="microsoft.scripting"
        type="Microsoft.Scripting.Hosting.Configuration.Section, Microsoft.Scripting"
        requirePermission="false" />
  </configSections>

  <microsoft.scripting>
    <languages>
      <language
        extensions=".js"
        displayName="IronJint"
        type="IronJint.Runtime.JavaScriptContext, IronJint"
        names="IronJint;JavaScript;js" />
      </languages>
  </microsoft.scripting>
</configuration>
```

3) Then, you can run JavaScript code on your .NET app
belong with the way of Microsoft DLR LanguageCOntext interface.

```csharp
using System;
using Microsoft.Scripting.Hosting;

class Program
{
  public class Greeting {
    public void Hello(string name) {
      Console.WriteLine("Hello " + name);
    }
  }

  static void Main() {
    var runtime = ScriptRuntime.CreateFromConfiguration();
    var engine = runtime.GetEngine("IronJint");

    var greeting = new Greeting();
    var scope = runtime.CreateScope();
    scope.SetVariable("greeting", greeting);

    var script = "greeting.Hello('Taro');";
    engine.Execute(script, scope); // Console out put is "Hello Taro"
  }
}
```

**NOTICE:** IronJint support above scenario only, because it's very very thin wrapper.

## Why do not I use native Jint without these warpper?

Because I want to use Jint with IronRuby and IronPython.

If you already have an app that has ability as extension by Microsoft DLR Scripting LanguageContext,
with IronRuby and/or IronPython, you can append JavaScript support very easily.

All you need is installing IronJint NuGet package and insert one line into .config file in `microsoft.scripting/languages` configuration section.

```xml
<language extensions=".js" displayName="IronJint" type="IronJint.Runtime.JavaScriptContext, IronJint" names="IronJint;JavaScript;js" />
```

## Why IronJint NuGet package is pre-release version?

IronJint depend on [Microsoft Dynamic Language Runtime](https://www.nuget.org/packages/DynamicLanguageRuntime), but DynamicLanguageRuntime NuGet package still pre-release version.

> IronRuby and IronPython are bundle Microsoft Dynamic Language Runtime(MS DLR) to their package. But, I think, it is too redundancy and cause many confusions. I think they should not bundle MS DLR, shoud depends on external MS DLR NuGet package.
