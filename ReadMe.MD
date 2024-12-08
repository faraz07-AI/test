VR Test Smell Detection Tool
The VR Test Smell Detection Tool is designed to detect and analyze various test smells in VR-based projects. This tool automates the detection of test smells, generates insights in CSV format, and helps improve test quality and maintainability. Below are the steps to configure, run, and utilize the tool effectively.

Project Overview
This tool detects test smells in Unity-based VR projects by analyzing repositories. It uses automation to clone the source code, process the files, and identify test smells, providing results in CSV format.

Test Smells Detected:
Assert Roulette
Eager Test
Lazy Test
Mystery Guest
Sensitive Equality
General Fixture
Prerequisites
Java Development Kit (JDK): Ensure JDK is installed and properly set up.
Git: Required for cloning repositories.
CSV Reader/Editor: To view the generated CSV files.
Repositories List: A text file containing repository links to analyze.
Project Structure
src/main/java:

Contains the core implementation files, including:
MainClass.java: Entry point to run the tool.
Config.java: Configuration file for repository paths and settings.
Project_Repo: Directory where repositories will be downloaded.

data: Directory containing files for configuration and analysis.

CSV Outputs: Results are saved as .csv files in the configured output directory.

Setup Instructions
1. Configure Config.java
Open src/main/java/config/Config.java.

Set the following:

rootDir: Path to the root directory where repositories will be stored.
repoDir: Directory under rootDir for storing downloaded repositories.
gitProjList: Path to the text file containing a list of repositories to analyze.
Example:

java

"""
public static String rootDir = "/home/user/Documents/UnityTestAnalysis/Project_Repo/";
public static String gitProjList = rootDir + "Project_Source.txt";
public static String repoDir = rootDir + "GitRepo/";
"""
2. Prepare Repository List
Create a file named Project_Source.txt in the configured path (gitProjList).

Add the repository URLs to this file, each on a new line.

Example:
"""
https://github.com/example/repo1.git
https://github.com/example/repo2.git

"""

Running the Tool
1. Clone Repositories
Run the tool and choose option 1 to download all repositories listed in Project_Source.txt.

The repositories will be cloned into the repoDir directory.

Example Command:

java MainClass

. Analyze Test Smells
After downloading the repositories, choose a test smell detection option (e.g., Assert Roulette, Lazy Test, etc.).
The tool will analyze the repositories and generate a CSV file for the selected test smell.

Output
CSV files are automatically generated in the specified output directory.
Each CSV file contains detailed information about the detected test smells.

How to View Results
Open the generated CSV files using any CSV reader/editor.
Analyze the data to identify and address the test smells in your VR projects.

Example Workflow
Configure Config.java with your repository paths.
Add repository links to Project_Source.txt.
Run the tool and select Option 1 to download repositories.
Choose a test smell option (e.g., Assert Roulette) to analyze the repositories.
View the results in the generated CSV file.

Contributors
Foyzul Hassan, 
Faraz Gurramkonda, 
Dhia Elhaq Rzig, 
clonedSemicolon
