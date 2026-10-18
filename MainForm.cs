using System.ComponentModel;

namespace JtronixAssessment;

/// <summary>
/// Single application covering all three questions.
/// Each question lives on its own tab of the same form:
///   1.1 Button click event
///   1.2 Change button and label text
///   1.3 Student GridView and search
/// </summary>
public class MainForm : Form
{
    // ---- 1.1 ----
    private readonly Button btnClickMe = new();
    private readonly Label lblMessage = new();

    // ---- 1.2 ----
    private readonly Button btnChange = new();
    private readonly Label lblChange = new();

    // ---- 1.3 ----
    private readonly Label lblSearch = new();
    private readonly TextBox txtSearch = new();
    private readonly Button btnSearch = new();
    private readonly DataGridView gridStudents = new();
    private readonly Label lblResult = new();

    private sealed record Student(string RollNumber, string StudentName);

    private readonly BindingList<Student> students = new()
    {
        new Student("101", "John Doe"),
        new Student("102", "Jane Smith"),
        new Student("103", "Batly Beam"),
        new Student("104", "Alape Alphar"),
        new Student("105", "Bavin Santh"),
        new Student("106", "Roben Smith"),
        new Student("999", "David Roba"),
    };

    public MainForm()
    {
        Text = "Simple C# Application";
        ClientSize = new Size(560, 380);
        StartPosition = FormStartPosition.CenterScreen;

        var tabs = new TabControl { Dock = DockStyle.Fill };
        var tab11 = new TabPage("1.1 Button Click Event");
        var tab12 = new TabPage("1.2 Change Button and Label Text");
        var tab13 = new TabPage("1.3 Student GridView and Search");
        tabs.TabPages.AddRange(new[] { tab11, tab12, tab13 });
        Controls.Add(tabs);

        BuildTab11(tab11);
        BuildTab12(tab12);
        BuildTab13(tab13);
    }

    // ------------------------------------------------------------
    // 1.1 Button Click Event
    // ------------------------------------------------------------
    private void BuildTab11(TabPage page)
    {
        btnClickMe.Text = "Click Me";
        btnClickMe.Size = new Size(100, 30);
        btnClickMe.Location = new Point(220, 110);
        btnClickMe.Click += BtnClickMe_Click;

        lblMessage.Text = "";
        lblMessage.AutoSize = false;
        lblMessage.TextAlign = ContentAlignment.MiddleCenter;
        lblMessage.Size = new Size(400, 30);
        lblMessage.Location = new Point(70, 160);

        page.Controls.Add(btnClickMe);
        page.Controls.Add(lblMessage);
    }

    private void BtnClickMe_Click(object? sender, EventArgs e)
    {
        lblMessage.Text = "Hello, Welcome to C#!";
    }

    // ------------------------------------------------------------
    // 1.2 Change Button and Label Text
    // ------------------------------------------------------------
    private void BuildTab12(TabPage page)
    {
        btnChange.Text = "Click Me";               // initial button text
        btnChange.Size = new Size(100, 30);
        btnChange.Location = new Point(220, 110);
        btnChange.Click += BtnChange_Click;

        lblChange.Text = "Welcome";                // initial label text
        lblChange.AutoSize = false;
        lblChange.TextAlign = ContentAlignment.MiddleCenter;
        lblChange.Size = new Size(400, 30);
        lblChange.Location = new Point(70, 160);

        page.Controls.Add(btnChange);
        page.Controls.Add(lblChange);
    }

    private void BtnChange_Click(object? sender, EventArgs e)
    {
        btnChange.Text = "Clicked";
        lblChange.Text = "Button clicked successfully!";
    }

    // ------------------------------------------------------------
    // 1.3 Student GridView and Search
    // ------------------------------------------------------------
    private void BuildTab13(TabPage page)
    {
        lblSearch.Text = "Roll Number Search:";
        lblSearch.AutoSize = true;
        lblSearch.Location = new Point(60, 22);

        txtSearch.Location = new Point(205, 18);
        txtSearch.Size = new Size(160, 23);
        txtSearch.KeyDown += (s, e) =>
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                PerformSearch();
            }
        };

        btnSearch.Text = "Search";
        btnSearch.Location = new Point(365, 16);
        btnSearch.Size = new Size(90, 27);
        btnSearch.Click += (s, e) => PerformSearch();

        gridStudents.Location = new Point(60, 60);
        gridStudents.Size = new Size(400, 200);
        gridStudents.AutoGenerateColumns = false;
        gridStudents.AllowUserToAddRows = false;
        gridStudents.AllowUserToDeleteRows = false;
        gridStudents.ReadOnly = true;
        gridStudents.RowHeadersVisible = true;
        gridStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        gridStudents.MultiSelect = false;
        gridStudents.Columns.Add(new DataGridViewTextBoxColumn
        {
            HeaderText = "Roll Number",
            DataPropertyName = nameof(Student.RollNumber),
            Width = 130,
        });
        gridStudents.Columns.Add(new DataGridViewTextBoxColumn
        {
            HeaderText = "Student Name",
            DataPropertyName = nameof(Student.StudentName),
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
        });
        gridStudents.DataSource = students;

        lblResult.Text = "";
        lblResult.AutoSize = false;
        lblResult.TextAlign = ContentAlignment.MiddleCenter;
        lblResult.Size = new Size(400, 30);
        lblResult.Location = new Point(60, 275);

        page.Controls.Add(lblSearch);
        page.Controls.Add(txtSearch);
        page.Controls.Add(btnSearch);
        page.Controls.Add(gridStudents);
        page.Controls.Add(lblResult);
    }

    private void PerformSearch()
    {
        string roll = txtSearch.Text.Trim();

        var match = students.FirstOrDefault(s =>
            string.Equals(s.RollNumber, roll, StringComparison.OrdinalIgnoreCase));

        if (roll.Length > 0 && match is not null)
        {
            lblResult.Text = $"Matching Student: {match.StudentName}";

            // Highlight the matching row in the grid
            gridStudents.ClearSelection();
            int index = students.IndexOf(match);
            gridStudents.Rows[index].Selected = true;
            gridStudents.CurrentCell = gridStudents.Rows[index].Cells[0];
        }
        else
        {
            lblResult.Text = "Student not found";
            gridStudents.ClearSelection();
        }
    }
}
