using Microsoft.EntityFrameworkCore.Migrations;

namespace Turnos.Infrastructure.Persistence.Extensions;

internal static class DataMigrationExtension
{
    public static MigrationBuilder RunFiles(this MigrationBuilder builder, string relativePath)
    {
        var path = $"{AppContext.BaseDirectory}\\{relativePath}\\";
        var files = Directory.GetFiles(path, "*.sql").ToList();
        files = files.OrderBy(x => x).ToList();

        foreach (var f in files) builder.Sql(File.ReadAllText(f));

        return builder;
    }


    public static MigrationBuilder RunFile(this MigrationBuilder builder, string relativeFilePath)
    {
        var path = $"{AppContext.BaseDirectory}\\{relativeFilePath}";
        builder.Sql(File.ReadAllText(path));

        return builder;
    }
}