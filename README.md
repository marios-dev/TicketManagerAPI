# TicketManagerAPI

## Overview

This application acts as a middleware integration between Teamwork a ticketing system used at companies and an internal task management system **Teamhood**.

It facilitates seamless communication and synchronization between the two systems to automate ticket handling and save significant time for consultants managing ERP-related customer issues.

## How It Works

- Teamwork receives customer support tickets reporting issues related to the ERP system.
- When ticket events occur (such as ticket creation or status changes), Teamwork sends HTTP POST requests to a DNS endpoint where this app listens.
- The app analyzes the incoming requests and triggers corresponding workflows based on the event type.

### Ticket Status Change Workflow

- For **new tickets**, the app:
  - Fetches full ticket details from the ticketing API.
  - Creates a corresponding ticket in the task management system.
  - Updates the ticket status in Teamwork to **"CreatedInTeamhood"**.

- For **ticket status updates**, the app:
  - Detects the new status.
  - Synchronizes the corresponding ticket status in the task management system accordingly.

## Benefits

- Ensures stable and reliable synchronization between Teamwork and the task management system.
- Reduces manual workload and coordination efforts for consultants.
- Provides a scalable solution for automating ERP issue tracking workflows.

## Technologies Used

- [.NET 7](https://dotnet.microsoft.com/)
- C#
- ASP.NET Core Minimal API (initially)
- Created with a god class but the initial plan is to do very few things, of course that changed quickly and there was no time from the company so God class it was!

## Setup & Usage

1. Clone this repository.
2. Configure the DNS endpoint to forward HTTP POST requests from Forward Teamwork.
3. Update app settings with API credentials for Teamwork and the task management system (teamhood).
4. Run the app and ensure it listens for incoming webhook events.
5. Monitor logs for event processing status.

*Created by Mario Syti*  
*For inquiries, contact: msyti@outlook.com*
