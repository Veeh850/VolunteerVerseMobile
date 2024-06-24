# Volunteer Coordination Platform Mobile View

This project is part of our bachelor's degree work, designed as a platform for volunteers and organizations to find and promote volunteer events. The mobile view currently supports basic functionalities, making it easy for users who prefer a mobile experience. For more comprehensive administrative features, please use the web version. We plan to continue expanding the mobile functionalities to enhance the overall experience for our users.

## Table of Contents
- [Features](#features)
- [Installation](#installation)
- [Configuration](#configuration)
- [Usage](#usage)

## Features
- **User authentication**: Secure login and registration for volunteers.
- **Browse and filter volunteering events**: Easily search and filter through available volunteering opportunities.
- **Apply for tasks**: Submit applications for tasks and volunteer events. 
- **Manage your organization**: If you are an organizer, manage your organization and its events.

## Installation
To get started with the mobile view application, follow these steps:

1. **Clone the repository**
   ```sh
   git clone https://github.com/your-username/VolunteerVerseMobile.git
   cd VolunteerVerseMobile

2. **Install .NET MAUI**
    
    Ensure you have .NET MAUI installed. Follow the official [installation](https://learn.microsoft.com/en-us/dotnet/maui/get-started/installation?view=net-maui-8.0&tabs=vswin) guide.

4. **Restore dependencies**
   ```sh
   dotnet restore
   
5. **Build the application**
   ```sh
   dotnet build

4. **Run the application**
   ```sh
   dotnet run

## Configuration
Before running the application, make sure to configure the necessary settings in the appsettings.json file. This includes setting up the API endpoint, authentication keys, and other relevant configurations.

## Usage 
After installing and configuring the application, you can start using it on your mobile device. The app allows volunteers to:

- **Log in or sign up**: Use your credentials to access the platform or create a new account.
- **Continue without login**: Browse volunteering options and organizations without logging in.
- **Apply for task**: Once logged in, you can apply for volunteer tasks.
- **Manage organization and events**: If you are an organizer, you can manage your organization and its events.
- **Manage your applied events**:  View and manage the events you've applied for on your profile page.
   
