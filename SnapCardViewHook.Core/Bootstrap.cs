using SnapCardViewHook.Core.Forms;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace SnapCardViewHook.Core
{
    public class Bootstrap
    {
        static Bootstrap()
        {
            AppDomain.CurrentDomain.AssemblyResolve += OnAssemblyResolve;
        }

        public static void Init(string settings)
        {
            try
            {
                SnapTypeDataCollector.EnsureLoaded();
                CreateForm();
#if DEBUG
                //MessageBox.Show("Loaded");
#endif
            }
            catch (Exception e) 
            {
                MessageBox.Show(
                    $"An error occured, SnapCardViewer has not loaded properly and will not function, an update might be required." +
                    $"\nError details:\n\n\n{e}",
                    "Error", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation);
            }
        }

        private static void CreateForm()
        {
            var t = new Thread(() =>
            {
                var f = new CardViewSelectorForm();
                Application.Run(f);
            });

            t.SetApartmentState(ApartmentState.STA);
            t.IsBackground = true;
            t.Start();
        }

        private static Assembly OnAssemblyResolve(object sender, ResolveEventArgs args)
        {
            var assemblyName = new AssemblyName(args.Name).Name;
            var directory = Path.GetDirectoryName(args.RequestingAssembly.Location);

            Debug.WriteLine($"resolving \"{assemblyName}\"");

            if (directory == null)
                return null;

            foreach (var file in Directory.GetFiles(directory, "*.dll"))
            {
                if (string.Equals(assemblyName, Path.GetFileNameWithoutExtension(file), StringComparison.InvariantCultureIgnoreCase))
                    return Assembly.LoadFile(file);
            }

            Debug.WriteLine($"resolve of \"{assemblyName}\" failed!");

            return null;
        }
    }
}
