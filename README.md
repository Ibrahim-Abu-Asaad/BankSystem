# 🏦 Apex Bank — Desktop Banking Management System

> A full-featured, role-based banking management application built with **C# Windows Forms** and **SQL Server**, implementing a clean 3-layer architecture with real-time validation, transactional integrity, and a comprehensive audit trail.

---

## 📸 Screenshots

Login Page
![Login](screenshots/Login%20Page.PNG)

---

Bank Interface Page
![BankInterface](screenshots/Bank%20Interface%20Page.PNG)

---

## 🧭 Table of Contents

- [Overview](#-overview)
- [Architecture](#️-architecture)
- [Features](#-features)
- [Tech Stack](#-tech-stack)
- [Database Design](#-database-design)
- [Modules](#-modules)
- [Security](#-security)
- [Getting Started](#-getting-started)
- [Project Structure](#-project-structure)
- [Author](#-author)

---

## 🔍 Overview

**Apex Bank** is a desktop banking system designed to simulate real-world bank operations. It supports multi-user access with granular role-based permissions, enabling Admins, Account Managers, Finance Managers, and Standard Users to interact with the system based on their authorization level.

The application handles client account management, monetary transactions (deposit, withdrawal, transfer), currency exchange rate tracking, and a full audit log of all system activity.

---

## 🏛️ Architecture

The project is built on a **3-Layer (N-Tier) Architecture**, strictly separating concerns:

```
┌─────────────────────────────────┐
│     Presentation Layer (UI)     │  Windows Forms — all screens & dialogs
├─────────────────────────────────┤
│   Business Logic Layer (BLL)    │  Validation, rules, transaction logic
├─────────────────────────────────┤
│   Data Access Layer (DAL)       │  SQL Server queries via stored procedures
└─────────────────────────────────┘
```

**Key design principles applied:**
- **Separation of Concerns** — each layer has a single, well-defined responsibility
- **Encapsulation** — business rules are hidden from the UI and inaccessible to the data layer
- **Modularity** — features (clients, users, transactions) are independently structured
- **OOP** — classes represent real-world entities with clear state and behavior

---

## ✨ Features

### 👤 User & Access Management
- Secure login system with show/hide password toggle
- Role-Based Access Control (RBAC) with fully configurable permissions per role
- Admin can add, edit, and delete users with assigned roles
- Profile management for all logged-in users

### 🏧 Client Account Management
- Full CRUD for bank clients (Create, Read, Update, Delete)
- Each client has a unique Account Number, PIN code, balance, and currency
- Profile photo support with set/remove functionality
- Search and filter clients by Account Number or Name

### 💸 Transactions
- **Deposit** — add funds to any client account
- **Withdraw** — deduct funds with balance sufficiency validation
- **Transfer** — move funds between two accounts in real time
- Dollar sign ($) indicator with live balance display
- Full transaction history in the **Transactions Register**

### 💱 Currencies Rate
- Displays real-time exchange rates for Middle Eastern and international currencies
- Base currency: USD, with rates for JOD, SYP, IQD, SAR, EGP, AED, KWD, LBP, and more

### 📋 Audit & Logging
- **Logins Register** — records every login event with timestamp, username, role, and full name
- **Transactions Register** — complete ledger with transaction type, amount, date, from/to accounts and person names, and currency

### 🔐 Roles & Permissions
- Configurable roles: Admin, Account Manager, Finance Manager, Standard User
- Granular permissions: `Client_AccessPage`, `Client_Create`, `Client_Edit`, `Client_Delete`, `Transaction_AccessPage`, `Transaction_Withdraw`, and more
- Admins automatically inherit all permissions
- Ability to add new custom roles at runtime

### ✅ Input Validation
- Real-time **ErrorProvider** validation on all input fields
- Validates: name, email format, phone number, address, date of birth, account number uniqueness, PIN strength, and password confirmation match
- Prevents saving until all required fields pass validation — no silent failures

---

## 🛠️ Tech Stack

| Layer | Technology |
|-------|-----------|
| Language | C# (.NET Framework) |
| UI Framework | Windows Forms (WinForms) |
| Database | Microsoft SQL Server |
| Data Access | ADO.NET with Stored Procedures |
| IDE | Visual Studio |
| Architecture | 3-Layer (Presentation / BLL / DAL) |

---

## 🗄️ Database Design

The SQL Server database uses a normalized relational schema with the following core tables:

```
Clients          → Stores client personal info, account number, PIN, balance, currency
Users            → Stores system users with login credentials and roles
Roles            → Defines available roles (Admin, Manager, etc.)
Permissions      → Maps permissions to roles
Transactions     → Logs every financial transaction with from/to accounts
LoginHistory     → Audit log of all login events
Currencies       → Currency codes and exchange rates vs. USD
```

**Key constraints enforced at the DB level:**
- Unique Account Numbers per client
- Foreign keys linking transactions to client accounts
- Non-nullable fields for critical financial data

---

## 📦 Modules

| Module | Description |
|--------|-------------|
| **Login** | Authenticates users, records login timestamp, enforces session |
| **Dashboard** | Role-aware home screen; shows only permitted navigation items |
| **Manage Clients** | Full client CRUD with search, pagination, and photo management |
| **Add / Edit Client** | Form with real-time validation, date picker, country dropdown |
| **Transactions** | Tabbed interface: Withdraw / Deposit / Transfer / Register |
| **Manage Users** | Admin-only user management with role assignment |
| **Add / Edit User** | User form with login credentials and role selector |
| **Currencies Rate** | Live currency rate table sorted by country |
| **Logins Register** | Searchable login audit log with date, username, role, name |
| **Transactions Register** | Full transaction ledger with type, accounts, amounts |
| **Roles & Permissions** | Permission matrix editor per role with save and add-new |
| **My Profile** | Editable personal profile for the currently logged-in user |

---

## 🔐 Security

- **Password hashing** — passwords are never stored in plain text
- **PIN masking** — client PINs are hidden by default with an opt-in Show checkbox
- **Session binding** — all actions are tied to the authenticated user's identity
- **Permission enforcement** — every sensitive screen checks the user's permission before rendering
- **Audit trail** — logins and all financial activity are permanently logged and cannot be deleted from the UI
- **Balance validation** — withdrawals and transfers are rejected server-side if balance is insufficient

---

## 🚀 Getting Started

### Prerequisites

- Windows OS
- Visual Studio 2019 or later
- SQL Server 2017 or later (or SQL Server Express)
- .NET Framework 4.7.2+

### Setup

1. **Clone the repository**
   ```bash
   git clone https://github.com/your-username/ApexBank.git
   cd ApexBank
   ```

2. **Restore the database**
   - Open SQL Server Management Studio (SSMS)
   - Run the script located at `Database/ApexBank_Schema.sql`
   - Then run `Database/ApexBank_SeedData.sql` for sample data

3. **Configure the connection string**
   - Open `DataAccessLayer/clsDataAccessSettings.cs`
   - Update the `Server` and `Database` fields to match your SQL Server instance:
     ```csharp
     public static string ConnectionString =
         "Server=YOUR_SERVER_NAME; Database=ApexBank; Integrated Security=True;";
     ```

4. **Build and Run**
   - Open `ApexBank.sln` in Visual Studio
   - Press `F5` or click **Start** to build and run

5. **Default Admin Login**
   ```
   Username: ibra
   Password: [set in seed data]
   ```

---

## 🗂️ Project Structure

```
ApexBank/
│
├── PresentationLayer/          # All Windows Forms screens
│   ├── frmLogin.cs
│   ├── frmMain.cs
│   ├── frmManageClients.cs
│   ├── frmAddEditClient.cs
│   ├── frmManageUsers.cs
│   ├── frmAddEditUser.cs
│   ├── frmTransactions.cs
│   ├── frmTransfer.cs
│   ├── frmCurrenciesRate.cs
│   ├── frmLoginsRegister.cs
│   ├── frmTransactionsRegister.cs
│   ├── frmRolesAndPermissions.cs
│   └── frmMyProfile.cs
│
├── BusinessLogicLayer/         # Validation, rules, computation
│   ├── clsClient.cs
│   ├── clsUser.cs
│   ├── clsTransaction.cs
│   ├── clsRole.cs
│   └── clsCurrency.cs
│
├── DataAccessLayer/            # SQL communication
│   ├── clsDataAccessSettings.cs
│   ├── clsClientData.cs
│   ├── clsUserData.cs
│   ├── clsTransactionData.cs
│   └── clsCurrencyData.cs
│
└── Database/
    ├── ApexBank_Schema.sql
    └── ApexBank_SeedData.sql
```

---

## 👨‍💻 Author

**Ibrahim Abu-Asaad**

- Built with passion as a full-stack desktop application demonstrating real-world software engineering principles
- Covers security, financial integrity, UI/UX, database design, and clean architecture in a single cohesive project

---

## 📄 License

This project is open-source and available under the [MIT License](LICENSE).

---

> *"Clean architecture is not about where you put the files — it's about which direction the dependencies point."*
