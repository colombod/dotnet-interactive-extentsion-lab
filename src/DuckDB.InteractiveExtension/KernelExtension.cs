﻿using Microsoft.AspNetCore.Html;
using Microsoft.DotNet.Interactive;

namespace DuckDB.InteractiveExtension;

public class KernelExtension
{
    public static void Load(Kernel kernel)
    {
        if (kernel is CompositeKernel compositeKernel)
        {
            compositeKernel
                .AddConnectDirective(new ConnectDuckDBDirective());

            KernelInvocationContext.Current?.Display(
                new HtmlString(@"<details><summary>Query DuckDB databases.</summary>
    <p>This extension adds support for connecting to <a href=""https://duckdb.org/"">DuckDB</a> databases using the <code>#!connect duckdb</code> magic command.
    </details>"),
                "text/html");
        }
    }
}