using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;




namespace AhmadShop.Infrastructure.ServicesConfig;


public static class SerilogConfigs
{

    /// <summary>
    /// Use SqlServer for logging and set set configs
    /// </summary>
    public static void UseSqlServer(IConfiguration configuration)

    {
        var connectionString = configuration.GetConnectionString("SqlConnectionString");


        Log.Logger = new LoggerConfiguration()
            .WriteTo.MSSqlServer(connectionString: connectionString
            , columnOptions: GetSqlColumnOptions()
            , sinkOptions: new MSSqlServerSinkOptions
            {
                TableName = "LoggServices",
                AutoCreateSqlTable = true,
            })
            .MinimumLevel.Information()
            .CreateLogger();


    }


    private static ColumnOptions GetSqlColumnOptions()
    {
        var colOptions = new ColumnOptions();
        colOptions.Store.Remove(StandardColumn.Properties);
        colOptions.Store.Remove(StandardColumn.MessageTemplate);
        colOptions.Store.Remove(StandardColumn.Message);
        colOptions.Store.Remove(StandardColumn.Exception);
        colOptions.Store.Remove(StandardColumn.TimeStamp);
        colOptions.Store.Remove(StandardColumn.Level);

        colOptions.AdditionalColumns = new Collection<SqlColumn>
    {
        new SqlColumn {DataType = SqlDbType.DateTime2, ColumnName = "DateTime"},
        new SqlColumn {DataType = SqlDbType.VarChar, ColumnName = "ServiceName"},
        new SqlColumn {DataType = SqlDbType.VarChar, ColumnName = "logLevel"},
        new SqlColumn {DataType = SqlDbType.Int ,ColumnName = "Line"},
        new SqlColumn {DataType = SqlDbType.VarChar, ColumnName = "Description"},
        new SqlColumn {DataType = SqlDbType.VarChar, ColumnName = "Source"},
        new SqlColumn {DataType = SqlDbType.VarChar, ColumnName = "Data"},
        new SqlColumn {DataType = SqlDbType.VarChar, ColumnName = "Exception"},
    };

        return colOptions;
    }

}

}
