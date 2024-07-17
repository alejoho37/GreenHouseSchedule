﻿using DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public static class DataBaseOperations
{
    public static async Task BackupDatabaseAsync()
    {
        using (var context = new SowScheduleContext())
        {
            var connection = context.Database.GetDbConnection();

            await connection.OpenAsync();

            using (var command = connection.CreateCommand())
            {
                var backupFileName = $"backup_{DateTime.Now:yyyyMMddHHmmss}.bak";
                var backupFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, backupFileName);

                command.CommandText = $"BACKUP DATABASE {connection.Database} TO DISK = '{backupFilePath}' WITH FORMAT, MEDIANAME = 'SQL_Backup', NAME = 'Full Backup of {connection.Database}';";
                await command.ExecuteNonQueryAsync();
            }

            await connection.CloseAsync();
        }
    }

}
