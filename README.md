# Driving License Management System

A comprehensive desktop application that simulates the real-world process of obtaining, renewing, and replacing driving licenses. Built to be used by government employees, the system helps manage citizens and foreigners applying for various classes of driving licenses.

![Driving License Database Diagram](https://user-images.githubusercontent.com/11928039/133873995-6a1a4fca-c08e-4083-b08d-cb224997d47d.png)

---

## Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Validations and Business Logic](#validations-and-business-logic)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
- [Installation](#installation)
- [Usage](#usage)
- [Screenshots](#screenshots)
- [Future Enhancements](#future-enhancements)

---

## Overview

This project is designed to streamline the process of issuing and managing driving licenses. By simulating real-world scenarios (e.g., different age limits, license classes, renewals, replacements, detentions), it offers an excellent opportunity to practice logical thinking and tackle complex business rules that mirror actual government procedures.

**Use Case**:
- Government clerks use the system on their local machines (Windows Forms application).
- The system connects to a database that stores all relevant data for people, drivers, licenses, test appointments, and more.

---

## Features

1. **Create New Driving Licenses**  
   - Supports seven distinct driving license classes (e.g., motorcycle, car, bus, etc.).
   - Assigns license numbers, issue dates, expiration dates, etc.

2. **Renew/Replace Licenses**  
   - Renews expired licenses and processes replacements for lost or damaged licenses.
   - Tracks renewal history and fees.

3. **Detain and Release Licenses**  
   - Allows enforcement officers or administrative staff to mark a license as detained.
   - Releases licenses once the detention reason has been resolved.

4. **Schedule Tests**  
   - Vision, theory, and street tests can be scheduled for applicants.
   - Tracks pass/fail results and re-examination requirements.

5. **Manage People and System Users**  
   - Store and retrieve personal information for citizens and foreigners.
   - Manage system users (e.g., staff, administrators) with appropriate permissions.

6. **Robust Validations**  
   - Validates minimum age requirements (e.g., 18 or 21) for certain license classes.
   - Ensures no duplicate license classes for the same individual.
   - Additional checks to maintain data integrity (e.g., preventing issuance to underage applicants).

---

## Validations and Business Logic

- **Age-Based Licensing**  
  - Applicants must meet minimum age thresholds (e.g., 18 for a standard car license, 21 for a bus license).

- **Unique Class Constraint**  
  - A single individual cannot hold multiple active licenses for the same class.

- **Detention & Release**  
  - Detained licenses cannot be renewed or replaced until officially released.

- **Test Scheduling**  
  - Must complete and pass prior stages (vision, theory) before scheduling the street test.

These rules ensure the system accurately reflects real-world regulations and fosters a deeper understanding of complex business logic.

---

## Technologies Used

- **C# / .NET Framework** for the Windows Forms application
- **Class Library Projects** for:
  - Business Logic (`DVLD_Business`)
  - Data Access (`DVLD_DataAccess`)
- **WinForms** (Presentation layer: `My_DVLD_Presentation`)
- **SQL Server**  for storing and managing data
- **Git** for version control

---

## Getting Started

1. **Clone the Repository**  
   - [Sign in to GitHub](https://github.com/) and navigate to your repository.  
   - Click **Code** → **Clone** or **Download ZIP**.

2. **Open in Visual Studio**  
   - Launch Visual Studio.  
   - Select **File** → **Open** → **Project/Solution**.  
   - Choose the `My_DVLD.sln` file.

3. **Restore NuGet Packages**  
   - If prompted, restore missing NuGet packages so all references are resolved.

---

## Installation


 **Build the Solution**  
   - In Visual Studio, select **Build** → **Build Solution**.  
   - Ensure all projects (`DVLD_Business`, `DVLD_DataAccess`, `My_DVLD_Presentation`) compile successfully.

---

## Usage

1. **Run the WinForms Application**  
   - From Visual Studio, set `My_DVLD_Presentation` as the startup project.  
   - Press **F5** (or **Debug** → **Start Debugging**) to launch the application.

2. **Login/Authentication** 
   - Enter valid credentials for a system user.

3. **Navigate the UI**  
   - **People**: Add new citizens or foreigners, edit their personal details.  
   - **Account Settings**: View logged in user info, edit their info, change password or sign out.  
   - **Applications**: Manage driving licenses, application types and test types 
   - **Drivers**: View all drivers, filter by license class, status, etc.
   - **Users**: Add or remove system users, activate or deactivate their accounts, etc.


4. **Validate**  
   - Attempt creating licenses for underage individuals to see how the validation is triggered.  
   - Test the system’s response to duplicating a license class for a single user.

---

## Screenshots

Below are a few screenshots illustrating core parts of the application:

1. **Main Dashboard**  
   ![Main Dashboard Screenshot](https://github.com/Reisha76/Driving-License-Management-System/blob/main/MAIN.png?raw=true)

2. **License Creation Form**  
   ![License Creation Form](https://github.com/Reisha76/Driving-License-Management-System/blob/main/Add%20local%20license.png?raw=true)

3. **People Management**  
   ![People Management Screenshot](https://github.com/Reisha76/Driving-License-Management-System/blob/main/People.png?raw=true)

---

## Future Enhancements

- **Online Portal Integration**  
  - Allow applicants to submit requests online, which staff can review in the WinForms app.

- **Payment Processing**  
  - Integrate with payment gateways for license fees.

- **Reporting and Analytics**  
  - Generate monthly/annual reports on issued, renewed, and detained licenses.

- **Automated Reminders**  
  - Email or SMS notifications for upcoming license renewals or scheduled tests.

- **Internationalization**  
  - Add multi-language support for non-English-speaking users.
