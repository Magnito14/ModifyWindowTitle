[DllImport("user32.dll")]
private static extern int SetWindowText(IntPtr hWnd, string text);

/// <summary>
/// This code imports the SetWindowText function from the user32.dll library,
/// which allows us to change the window title of a process.
/// </summary>
/// <param name="choice"></param>
/// <param name="combo_box"></param>
/// <param name="process_name"></param>
/// <param name="win_title"></param>
public void set_window_title(title_choice choice, ComboBox combo_box, string process_name = "", string win_title = "")
{
    switch (choice)
    {
        case title_choice.mod_title:
            foreach (var proc in Process.GetProcessesByName(process_name))
                SetWindowText(proc.MainWindowHandle, win_title);
            break;
        case title_choice.refresh_box:
            foreach (var proc in Process.GetProcesses())
            {
                if (!combo_box.Items.Contains(proc.ProcessName))
                    combo_box.Items.Add(proc.ProcessName);
            }
            break;
    }
}

/// <summary>
/// This enum defines the possible values for the choice
/// parameter of the set_window_title method.
/// </summary>
public enum title_choice
{
    mod_title,
    refresh_box
}
