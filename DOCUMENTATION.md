# School Management System - Documentation

This document provides technical documentation for the School Management System application.

## 1. Database Schema

The application uses an encrypted SQLite database (via SQLCipher) for local data storage. The database consists of the following tables:

### `SchoolInfo`
Stores basic information about the school.
- `Id` (INTEGER, PK, AI): Unique identifier.
- `Name` (TEXT): The name of the school.
- `Logo` (BLOB): The school's logo image data.

### `Roles`
Defines the user roles in the system.
- `Id` (INTEGER, PK, AI): Unique identifier.
- `RoleName` (TEXT, UNIQUE): The name of the role (e.g., "Management", "Admin").

### `Users`
Stores user account information.
- `Id` (INTEGER, PK, AI): Unique identifier.
- `Username` (TEXT, UNIQUE): The user's login name.
- `PasswordHash` (TEXT): The BCrypt-hashed password.
- `RoleId` (INTEGER, FK to Roles): The user's role.

### `LicenseInfo`
Stores the software license information.
- `LicenseKey` (TEXT, PK): The license key provided to the user.
- `ExpirationDate` (DATETIME): The date the license expires.
- `IsActive` (BOOLEAN): Whether the license is currently active.

### `Students`
Stores detailed information for each student.
- `Id` (INTEGER, PK, AI): Unique identifier.
- `AdmissionNumber` (TEXT): The student's unique admission number.
- `FirstName` (TEXT): The student's first name.
- `LastName` (TEXT): The student's last name.
- ... (and other personal, contact, and guardian details)
- `ClassId` (INTEGER, FK to Classes): The student's class.
- `SectionId` (INTEGER, FK to Sections): The student's section.

### `Classes`
- `Id` (INTEGER, PK, AI): Unique identifier.
- `ClassName` (TEXT, UNIQUE): The name of the class (e.g., "Grade 10").

### `Sections`
- `Id` (INTEGER, PK, AI): Unique identifier.
- `SectionName` (TEXT, UNIQUE): The name of the section (e.g., "A").

### `Subjects`
- `Id` (INTEGER, PK, AI): Unique identifier.
- `SubjectName` (TEXT, UNIQUE): The name of the subject (e.g., "Mathematics").

### `FeeStructures`
Defines the fee components for each class.
- `Id` (INTEGER, PK, AI): Unique identifier.
- `ClassId` (INTEGER, FK to Classes): The associated class.
- `FeeComponent` (TEXT): The name of the fee component (e.g., "Tuition Fee").
- `Amount` (DECIMAL): The amount for this component.

### `FeePayments`
Records payments made by students.
- `Id` (INTEGER, PK, AI): Unique identifier.
- `StudentId` (INTEGER, FK to Students): The student who made the payment.
- `AmountPaid` (DECIMAL): The amount paid.
- `PaymentDate` (DATETIME): The date of the payment.
- ... (and other details like fine, discount)

### `Invoices`
Stores information about generated invoices.
- `Id` (INTEGER, PK, AI): Unique identifier.
- `StudentId` (INTEGER, FK to Students): The associated student.
- `InvoiceDate` (DATETIME): The date the invoice was generated.
- `TotalAmount` (DECIMAL): The total amount of the invoice.
- `Status` (TEXT): The status of the invoice (e.g., "Paid", "Unpaid").

## 2. Security Protocols

### Local Data Encryption
All data at rest is stored in an encrypted SQLite database file (`School.db3`). The encryption is handled by **SQLCipher**, which uses AES-256 encryption. The database is password-protected, and the key is managed within the application's services.

### Password Hashing
User passwords are never stored in plain text. All passwords are hashed using the **BCrypt** algorithm, provided by the `BCrypt.Net-Next` library. This is a strong, adaptive hashing algorithm that includes a salt with each hash to protect against rainbow table attacks.

## 3. API Endpoints

The application communicates with a cloud server for one purpose only: initial license authentication.

### `POST /api/license/validate`
Validates a new license key.

**Request Body:**
```json
{
  "licenseKey": "USER-PROVIDED-LICENSE-KEY",
  "deviceId": "A-UNIQUE-DEVICE-IDENTIFIER"
}
```

**Success Response (200 OK):**
```json
{
  "isValid": true,
  "expirationDate": "YYYY-MM-DDTHH:mm:ssZ"
}
```

**Error Response (400 Bad Request / 404 Not Found):**
```json
{
  "isValid": false,
  "error": "Invalid or expired license key."
}
```
This endpoint is designed to be called only once per installation during the initial setup. Subsequent license checks are performed locally against the encrypted database.
