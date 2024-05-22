﻿using Juniansoft.SDEmu.Services;
using System;
using System.IO;
using WixSharp;

namespace Juniansoft.SDEmu.Setup
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string TargetFramework = "net462";
            const string ProgramFilesDir = "%ProgramFiles%";
            const string ProgramMenuDir = "%ProgramMenu%";
            const string InstallDir = "[INSTALLDIR]";

            var assembly = new AssemblyService(typeof(AssemblyService).Assembly);

            var project = new Project(
                name: $"{assembly.Title}",
                new Dir(
                    targetPath: Path.Combine(
                        ProgramFilesDir,
                        assembly.Company,
                        assembly.Product),
                    new Files(
                        sourcePath: Path.Combine(
                            "..",
                            $"{assembly.Title}.Win",
                            "bin",
                            assembly.Configuration,
                            TargetFramework,
                            "*.*"),
                        filter: f => !f.EndsWith(".obj"))
                    {
                    },
                    new ExeFileShortcut(
                        name: $"Uninstall {assembly.Product}",
                        target: "[System64Folder]msiexec.exe",
                        arguments: "/x [ProductCode]")
                ),
                new Dir(
                    targetPath: Path.Combine(
                        ProgramMenuDir,
                        assembly.Company,
                        assembly.Product),
                    new ExeFileShortcut(
                        name: $"{assembly.Product}",
                        target: Path.Combine(InstallDir, $"{assembly.Title}.Win.exe"),
                        arguments: "")
                    {
                        WorkingDirectory = InstallDir
                    },
                    new ExeFileShortcut(
                        name: $"Uninstall {assembly.Product}",
                        target: "[System64Folder]msiexec.exe",
                        arguments: "/x [ProductCode]")
                ),
                new EnvironmentVariable("Path", InstallDir)
                {
                    Id = "Path_INSTALLDIR",
                    Action = EnvVarAction.set,
                    Part = EnvVarPart.last,
                    Permanent = false,
                    System = true,
                }
            )
            {
                // DO NOT Change, should be {1D32E0B8-D829-4969-B546-FA57B6ED7189}
                // Same with UpgradeCode
                GUID = new Guid("1D32E0B8-D829-4969-B546-FA57B6ED7189"),
                Name = assembly.Product,
                Version = assembly.Version,
                MajorUpgradeStrategy = MajorUpgradeStrategy.Default,

            };

            project.MajorUpgradeStrategy.RemoveExistingProductAfter = Step.InstallInitialize;

            project.ResolveWildCards(pruneEmptyDirectories: true)
                   .FindFirstFile($"{assembly.Title}.exe")
                   .Shortcuts = new[]
                   {
                       new FileShortcut($"{assembly.Title}.exe", "%Desktop%")
                   };

            Compiler.PreserveTempFiles = true;
            Compiler.EmitRelativePaths = false;

            project
                .BuildMsi(path: Path.Combine(
                    "wix",
                    assembly.Configuration,
                    TargetFramework,
                    $"{assembly.Title}-v{assembly.Version.ToString(3)}.msi"));

        }
    }
}