<<<<<<< HEAD
# JTRONIX C# Desktop Internship Assessment

A single C# Windows Forms application (.NET 8) that covers all three assessment questions. Each question is on its own tab of the same form.

| Tab | Question | What it does |
|-----|----------|--------------|
| 1.1 Button Click Event | 1.1 | Button `Click Me` shows `Hello, Welcome to C#!` in a label. |
| 1.2 Change Button and Label Text | 1.2 | Starts as `Click Me` / `Welcome`. After clicking: button becomes `Clicked`, label becomes `Button clicked successfully!`. |
| 1.3 Student GridView and Search | 1.3 | DataGridView with `Roll Number` and `Student Name`. Enter a roll number and press `Search` (or Enter) to show `Matching Student: <name>`, or `Student not found`. |

## Requirements

- Windows 10 or 11
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0), or Visual Studio 2022 with the ".NET desktop development" workload

## How to run

### Option A: Visual Studio 2022
1. Unzip the project.
2. Double-click `JtronixAssessment.csproj` to open it in Visual Studio.
3. Press **F5** (or click **Start**).

### Option B: Command line
```
cd JtronixAssessment
dotnet run
```

## Testing the student search

- Enter `102` and click **Search**: `Matching Student: Jane Smith` is shown and the row is highlighted.
- Enter `555` and click **Search**: `Student not found` is shown.

Sample data: 101 John Doe, 102 Jane Smith, 103 Batly Beam, 104 Alape Alphar, 105 Bavin Santh, 106 Roben Smith, 999 David Roba.

## Project structure

```
JtronixAssessment/
  JtronixAssessment.csproj
  Program.cs        entry point
  MainForm.cs       UI and logic for all three questions
  README.md
  screenshots/      add your screenshots here
```


