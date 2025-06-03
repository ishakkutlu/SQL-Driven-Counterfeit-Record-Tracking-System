# SQL-Driven Counterfeit Record Tracking System

This repository contains a functional prototype focused on the core counterfeit record tracking in a multi-branch institutional context, combining SQL Server stored procedures with a set of simple C# interfaces. The system simulates a realistic institutional workflow under a simplified architecture, demonstrating real-time data validation, transactional integrity, and database synchronization through UI-triggered operations.

## Key Highlights:

- Fully normalized schema (conceptual, logical, physical)
- Stored procedures for CRUD (create/insert/update/delete) operations with rollback protection
- Serialization-level transactions ensuring consistency
- Fully working model for simulation and testing purposes

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

## Screenshots – Prototype in Action

**01 Initial Counterfeit Records**  
![01 Initial Counterfeit Records](./01_Initial_Counterfeit_Records.png)

**02 Viewer Panel**  
![02 Viewer Panel](./02_Viewer_Panel.png)

**03 New Record Entry**  
![03 New Record Entry](./03_New_Record_Entry.png)

**04 New Record Reflected in UI**  
![04 New Record Reflected in UI](./04_New_Record_Reflected_in_UI.png)

**05 New Record Confirmed in SQL Server**  
![05 New Record Confirmed in SQL Server](./05_New_Record_Confirmed_in_SQL_Server.png)

**06 Update Panel**  
![06 Update Panel](./06_Update_Panel.png)

**07 Updated Record Reflected in UI**  
![07 Updated Record Reflected in UI](./07_Updated_Record_Reflected_in_UI.png)

**08 Updated Record Confirmed in SQL Server**  
![08 Updated Record Confirmed in SQL Server](./08_Updated_Record_Confirmed_in_SQL_Server.png)

**09 Delete Request**  
![09 Delete Request](./09_Delete_Request.png)

**10 Delete Operation Confirmed in UI**  
![10 Delete Operation Confirmed in UI](./10_Delete_Operation_Confirmed_in_UI.png)

**11 Deleted Record Reflected in SQL Server**  
![11 Deleted Record Reflected in SQL Server](./11_Deleted_Record_Reflected_in_SQL_Server.png)

**12 Validation Alert**  
![12 Validation Alert](./12_Validation_Alert.png)

**13 Duplicate Entry Prevented – Add Operation**  
![13 Duplicate Entry Prevented – Add Operation](./13_Duplicate_Entry_Prevented_Add_Operation.png)

**14 Duplicate Entry Prevented – Update Operation**  
![14 Duplicate Entry Prevented – Update Operation](./14_Duplicate_Entry_Prevented_Update_Operation.png)

**15 Conceptual Data Model**  
![15 Conceptual Data Model](./15_Conceptual_Data_Model.png)

**16 Logical Data Model**  
![16 Logical Data Model](./16_Logical_Data_Model.png)

## Tools Used in Implementation:

- T-SQL
- SQL
- C#
- Microsoft SQL Server Management Studio 19.0.2
- Microsoft Visual Studio Community 2022 (64-bit), Version 17.6.2
- Microsoft Net Framework Version 4.8.04084

Note: The C# code provided here is minimal and serves only to simulate data flow between the UI and the SQL backend. The focus of this project is on the SQL architecture, data integrity, and stored procedure logic.

