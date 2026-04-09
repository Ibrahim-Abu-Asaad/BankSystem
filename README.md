# 🏦 Apex Bank - Desktop Management System

[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![.NET Framework](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=.net&logoColor=white)](https://dotnet.microsoft.com/en-us/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)](https://www.microsoft.com/en-us/sql-server)

**Apex Bank** is a high-performance administrative banking application built with a robust **3-Layer Architecture**. It features a sophisticated permission-based system, real-time transaction handling, and comprehensive auditing tools designed for modern financial management.

> [!CAUTION]
> **Work in Progress:** This project is currently under active development. Database scripts and full functionality are being updated regularly.

---

## 📖 Table of Contents
* [🚀 Key Features](#-key-features)
* [🛠 Tech Stack](#-tech-stack)
* [📂 Project Structure](#-project-structure)
* [📸 Screenshots](#-screenshots)
* [📥 Setup & Installation](#-setup--installation)

---

## 🚀 Key Features

### 👤 Advanced User & Profile Management
* **Granular RBAC:** Role-Based Access Control allowing specific permissions for *Admin*, *Finance Manager*, and *Account Manager*.
* **Secure Login Register:** An automated audit trail tracking every user session and login timestamp.
* **Personalized Profiles:** Users can manage their own credentials and profile imagery directly from the "My Profile" module.

### 💸 Transaction Engine
* **Core Operations:** Fully implemented modules for **Deposits**, **Withdrawals**, and **Transfers**.
* **Real-time Validation:** Integrated balance checking within the Logic Layer to prevent overdrafts.
* **Transaction Register:** Comprehensive logs documenting every movement of funds, including sender/receiver data and currency codes.

### 💰 Global Banking & Security
* **Multi-Currency Support:** Manage account balances with integrated currency rate tracking (USD, JOD, SAR, etc.).
* **Error Provider Validation:** Robust input validation across all forms (Email, Phone, PIN) to ensure data integrity and a smooth UX.

---

## 🛠 Tech Stack

* **Language:** C#
* **Framework:** .NET (Windows Forms)
* **Database:** Microsoft SQL Server
* **Architecture:** 3-Layer Design (UI, Business Logic, Data Access)

---

## 📂 Project Structure

The solution is organized into three distinct layers to ensure separation of concerns and maintainability:

* 🖥️ **`BankSystemUI`** - The Presentation Layer handling Windows Forms and user interaction.
* 🧠 **`BankSystemBLL`** - The Business Logic Layer managing validations, permissions, and calculations.
* 💾 **`BankSystemDAL`** - The Data Access Layer handling SQL queries and database connectivity.

---

## 📸 Screenshots

### 🖥️ Dashboard & Administration
| Main Interface | User Permissions |
|---|---|
| ![Main Interface](./screenshots/Bank_Interface_Page.jpg) | ![Permissions](./screenshots/Roles_And_Permissions_Page.PNG) |

### 💳 Financial Transactions
| Transfer System | Transactions Register |
|---|---|
| ![Transfer](./screenshots/Transfer_Page.jpg) | ![Log](./screenshots/Transactions_Register_Page.jpg) |

### 📋 Client & User Management
| Manage Clients | Add New User |
|---|---|
| ![Clients](./screenshots/Manage_Clients_Page.PNG) | ![Add User](./screenshots/Add_New_User_Page.PNG) |

---

## 📥 Setup & Installation

1. **Clone the repository:**
   ```bash
   git clone [https://github.com/Ibrahim-Abu-Asaad/BankSystem.git](https://github.com/Ibrahim-Abu-Asaad/BankSystem.git)
   cd BankSystem
   ```
2. Database Configuration:
   Ensure SQL Server is installed and running.
   Update the connection string in clsDataAccessSettings located within the DAL layer.
   (Note: Database backup/scripts will be added to the /DB folder soon).

3. Build the Project:
   Open the .sln file in Visual Studio.
   Restore NuGet packages if prompted.
   Press F5 to build and run the application.

Developed by (https://github.com/Ibrahim-Abu-Asaad)[Ibrahim Abu-Asaad]
