 # Log4NetHelper
Some helper methods for Log4Net on the .Net Standard platform.

## AdoNetAppenderHelper

Now it is possible to set the `connectionstring` directly at runtime, instead of ConnectionStringName and/or ConnectinStringFile.

Simply call:
```
AdoNetAppenderHelper.SetConnectionString(configuration.GetConnectionString("log4net"));
```
Do this call immediately after `log4net.Config.XmlConfigurator.Configure()`

## InternalDebugHelper

Enable (and disable) internal debugging of Log4Net.

```
InternalDebugHelper.EnableInternalDebug((source, args) =>
{
    Console.WriteLine(args.LogLog);
});
```

## ConfigurationHelper

List all configuration messages

```
foreach (var log in ConfigurationHelper.ListConfigurationMessages())
{
    Console.WriteLine(log);
}
```

-----
See also how to bring Log4NetAdoNetAppender to live on the .Net Standard platform here: [https://github.com/microknights/Log4NetAdoNetAppender](https://github.com/microknights/Log4NetAdoNetAppender)