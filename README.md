# SMSAlertSys (in early development)

# Date and Notification Management Application

## Overview

This C# .NET WinForms application is designed to manage and notify users of important dates and timestamps. The application saves these dates to a local SQL Server database and optionally to XML files for broader accessibility. Notifications are sent via email (SMTP) and potentially via SMS in the future, using a dedicated server or device.

## Key Features

1. **Date and Time Management**:
   - Users can input important dates and associated timestamps.
   - These dates are stored in an SQL Server database for persistent storage.
   - Dates can also be saved in XML format for portability and accessibility.

2. **Notifications**:
   - The application will notify users of upcoming dates via email using SMTP.
   - Future functionality will include SMS notifications, which will require a server or device equipped with an antenna and SIM card.

3. **Database Integration**:
   - The application uses an SQL Server running on localhost, managed via XAMPP, to store date and time entries.
   - SQL queries will handle the insertion, retrieval, and management of these entries.

4. **XML File Storage**:
   - Dates and timestamps can be exported to and imported from XML files.
   - This allows users to share data across different installations of the application.

## Implementation Details

1. **WinForms Application**:
   - A user-friendly graphical interface built with Windows Forms (WinForms).
   - Input forms for users to enter and edit dates and timestamps.
   - Display lists of upcoming dates and notifications.

2. **SQL Server Database**:
   - A local SQL Server database set up using XAMPP (localhost) to store date and time entries.
   - Tables designed to handle the necessary data, with columns for date, time, description, and notification status.

3. **Email Notifications**:
   - Integration with an SMTP server to send email notifications.
   - Configurable email settings (SMTP server address, port, credentials) within the application.
   - Email notifications triggered based on upcoming dates.

4. **Future SMS Notifications**:
   - Planning for future implementation of SMS notifications.
   - Requires a dedicated server or electronic device with an antenna and SIM card.
   - Integration with SMS gateway or direct SMS sending capabilities.

5. **XML File Handling**:
   - Methods to export date and time entries to XML files.
   - Methods to import date and time entries from XML files.
   - Ensures data can be easily shared and backed up.

## Example Workflow

1. **User Input**:
   - The user opens the application and enters a new date and time through the WinForms interface.
   - The entry is saved to the local SQL Server database and optionally exported to an XML file.

2. **Notification Setup**:
   - The application checks the database for upcoming dates.
   - When a date approaches, the application sends an email notification via the configured SMTP server.
   - In the future, the application will also send an SMS notification.

3. **Data Management**:
   - The user can view, edit, or delete entries through the interface.
   - The application ensures the SQL database and XML files are updated accordingly.

## Benefits

- **User-Friendly**: The WinForms interface makes it easy for users to manage their important dates.
- **Persistent Storage**: SQL Server database ensures data is securely stored and managed.
- **Portability**: XML file support allows data to be shared and accessed across different systems.
- **Scalability**: The application is designed to incorporate additional notification methods, such as SMS, enhancing its functionality.

This application combines the robustness of .NET technologies with the practicality of email and SMS notifications, providing a comprehensive solution for managing and reminding users of important dates.
