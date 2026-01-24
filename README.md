# Agenda Management API

This project is a backend API designed to manage multi-tenant agendas, companies, employees, and appointment scheduling.
It is intended as a portfolio project, focused on clean architecture, scalability, and proper separation of concerns.

---

## 🚀 Current Features

### Accounts
- Create an account
- Create a turn (appointment)

### Companies
- Create a company
- Hire an employee
- Fire an employee

### Agenda
- Create an agenda
- Define rules for each agenda
- Slot generation based on agenda rules  
  - Slots are dynamically generated from agenda configuration  
  - No hardcoded turn times
- Multi-agenda support per company  
  - A company can manage multiple agendas  
  - Employees can belong to one or more agendas

---

## ✅ Implemented Business Rules

- Accounts are unique using DNI (or equivalent document)
- Companies are unique using Social Reason (not CUIT)
- Turns cannot overlap (no superposed appointments)
- Turn duration is configurable per agenda
- Clients cannot create turns outside working hours
- Centralized business logic:
  - Controllers only expose endpoints
  - Services contain all domain logic
  - Repositories handle persistence only
  - DTOs and mappers are used for data transfer

---

## 🔄 Turn Lifecycle

Each turn follows a defined lifecycle:
- Pending
- Confirmed
- Cancelled
- Completed

---

## 🧱 Architecture Overview

- Controllers  
  - HTTP endpoints only
  - No business logic
- Services  
  - Core business rules and validations
- Repositories  
  - Database access layer
- DTOs & Mappers  
  - Input/output abstraction
- Clear separation of concerns following clean architecture principles

---

## 🛠 Features to Implement

- Agenda availability exceptions:
  - Holidays
  - Non-working days
  - Custom blocked time ranges
- Client restrictions:
  - Clients cannot create turns in the past
  - Clients can only see and manage their own turns
- Employee permissions:
  - Employees can manage all turns of their respective agendas
- Authentication & Authorization:
  - JWT-based sessions
  - Role-based access (Client, Employee, Owner)

---

## ⚠️ Notes

This initial release establishes the core functionality.
Further improvements and bug fixes will be addressed in upcoming commits.
