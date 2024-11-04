# JourneyPlannerSteps Automation

This repository contains an automated test suite using Selenium WebDriver and SpecFlow to validate functionalities on the **Transport for London (TfL)** website. The tests navigate through the journey planner features on the TfL website, performing and validating journey searches, updating preferences, and handling different scenarios related to journey planning.

## Table of Contents
- [Overview](#overview)
- [Features](#features)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Usage](#usage)
- [Test Scenarios](#test-scenarios)
- [Contributing](#contributing)
- [License](#license)

## Overview

The `JourneyPlannerSteps` class implements BDD-style tests using:
- **Selenium WebDriver** for browser automation
- **SpecFlow** for defining and executing Gherkin-based BDD scenarios
- **NUnit** for assertions and test validations
- **SeleniumExtras.WaitHelpers** to manage explicit waits for elements

The tests automate interactions with the TfL journey planner to verify:
- Navigation and page loads
- Input fields for journey start and end locations
- Suggestions and button interactions
- User preferences such as "Routes with least walking"
- Validation of journey results and error handling

## Features

- **Cookie Handling**: Accepts cookies to proceed with the page interaction.
- **Location Input**: Inputs departure and arrival locations with error handling.
- **Suggestions Selection**: Selects suggested locations based on input.
- **Journey Preferences**: Updates journey preferences (e.g., routes with the least walking).
- **Error Message Handling**: Validates error messages when required fields are empty.

## Prerequisites

Ensure the following are installed:
- .NET SDK
- NUnit
- ChromeDriver
- SpecFlow
- Selenium WebDriver for .NET

## Installation

1. **Clone the repository**:
   ```bash
   git clone https://github.com/yourusername/JourneyPlannerSteps.git
   ```

2. **Install dependencies**:
   Navigate to the project directory and restore packages:
   ```bash
   dotnet restore
   ```

3. **ChromeDriver Setup**:
   Ensure `chromedriver` matches your version of Chrome and is accessible in your system path.

## Usage

Run the tests using the following command:
```bash
dotnet test
```

The tests will launch an instance of Chrome to perform the steps defined in the SpecFlow feature files. Results and any test output can be viewed in the test results output.

## Test Scenarios

### Scenario: Navigating to TfL Homepage
- **Step**: Given I navigate to the TfL homepage
- **Description**: Opens the TfL website and maximizes the browser window. Accepts cookies if the banner appears.

### Scenario: Planning a Journey
- **Steps**:
  - Enter "From" and "To" locations
  - Select suggestions for each location
  - Click "Plan my journey" button
- **Validation**: Verifies that journey results, walking, and cycling times are displayed.

### Scenario: Updating Journey Preferences
- **Steps**:
  - Click "Edit preferences"
  - Select "Routes with least walking"
  - Click "Update journey" button
- **Validation**: Verifies that the journey time updates according to preferences.

### Scenario: Error Handling
- **Steps**:
  - Leave "From" and "To" locations empty
- **Validation**: Asserts that appropriate error messages are displayed for empty fields.

### Additional Scenarios
- View journey details for specified stations.
- Handle cases where no journey results are found, and display error messages.

## Contributing

If you'd like to contribute to this project:
1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a pull request

## License

This project is licensed under the MIT License. See the `LICENSE` file for details.
