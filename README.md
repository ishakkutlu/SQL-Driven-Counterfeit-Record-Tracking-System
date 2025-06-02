# SQL-Driven Counterfeit Record Tracking System

This repository contains a functional prototype focused on the core counterfeit record tracking across bank branches, combining SQL Server stored procedures with a simple C# interface. The system simulates a real institutional workflow under a simplified architecture, demonstrating real-time data validation, transactional integrity, and database synchronization through UI-triggered operations.

## Key Highlights:

- Fully normalized schema (conceptual, logical, physical)
- Stored procedures for CRUD (create/insert/update/delete) operations with rollback protection
**✦ Serialization-level transactions ensuring consistency
**✦ Fully working model for simulation and testing purposes

## Technical Highlights:

**✦ Error Handling & Validation**  
Implemented structured error handling and input validation within SQL procedures to ensure data consistency and prevent faulty inserts.

**✦ Referential Integrity & Normalization**  
Database schema designed with referential integrity constraints (PK–FK) and normalized structure to support clean data operations across linked tables.

**✦ Stored Procedure Abstraction**  
Encapsulated key operations (add, update, delete) in modular stored procedures for maintainability, reusability, and UI backend syncing.

**✦ Transaction Management**  
Critical updates wrapped in explicit transactions to prevent partial data saves and maintain system reliability during multi-step operations.

**✦ Live UI–DB Synchronization**  
Changes triggered via the C# interface are reflected instantly in the SQL Server backend, simulating a real-time data application.

## Tools Used in Implementation:

- T-SQL
- SQL
- C#
- Microsoft SQL Server Management Studio 19.0.2
- Microsoft Visual Studio Community 2022 (64-bit), Version 17.6.2
- Microsoft Net Framework Version 4.8.04084
