# Journey Planner Automation - README

This project automates the testing of the Transport for London (TfL) journey planner website using Selenium WebDriver in C#, SpecFlow for BDD-style testing, and NUnit for assertions. The code defines steps that simulate user interactions with the TfL website's journey planning features, including setting preferences and verifying journey results.

## Prerequisites

1. **.NET SDK**: Ensure you have .NET SDK installed (required for C# development).
2. **ChromeDriver**: ChromeDriver executable should match the version of Chrome installed on your system.
3. **NuGet Packages**:
   - `Selenium.WebDriver`
   - `Selenium.WebDriver.ChromeDriver`
   - `Selenium.Support`
   - `NUnit`
   - `NUnit3TestAdapter`
   - `SpecFlow`

## Project Structure

The main code file is `JourneyPlannerSteps.cs`, which contains the SpecFlow bindings for step definitions used in the feature file.

### Key Classes and Methods

- **`SetUp()`**: Initializes the Chrome WebDriver, maximizes the browser window, navigates to the TfL homepage, and accepts cookies.
- **`AcceptCookies()`**: Waits for and clicks on the cookie consent banner if it appears.
- **`Cleanup()`**: Closes the browser after each test scenario.
- **Interaction Methods**:
  - **`EnterLocation(string location, string fieldId)`**: Enters a location in the specified input field.
  - **`SelectSuggestion(string location)`**: Selects a location suggestion from the autocomplete list.
  - **`ClickButtonById(string buttonId)`**: Clicks a button by its HTML ID.
  - **`ClickButtonByCss(string cssSelector)`**: Clicks a button using a CSS selector.

### SpecFlow Step Definitions

The following SpecFlow steps are defined in this class:

- **Given Steps**:
  - `Given I navigate to the TfL homepage`
  - `Given I have planned a journey from "<fromLocation>" to "<toLocation>"`
  - `Given I have updated preferences`

- **When Steps**:
  - `When I enter "<fromLocation>" in the from location`
  - `When I select "<location>" from suggestions`
  - `When I enter "<toLocation>" in the to location`
  - `When I click Plan my journey`
  - `When I click Update journey`
  - `When I click Edit preferences`
  - `When I select Routes with least walking`
  - `When I click View Details`
  - `When I do not enter any locations`

- **Then Steps**:
  - `Then I should see the updated journey time`
  - `Then I should see the walking and cycling time results`
  - `Then I should see complete access information for "<stationName>"`
  - `Then I should see an error message indicating no results found`
  - `Then I should see an error message indicating that locations are required`

## How to Run the Tests

1. Open the solution in Visual Studio or another C# IDE.
2. Build the solution to install required dependencies.
3. Run the tests using:
   - The Test Explorer in Visual Studio
   - Or run them from the command line with:
     ```bash
     dotnet test
     ```

## Notes

- The **`AcceptCookies()`** method uses a `Thread.Sleep(2000)` to handle possible delays in the appearance of the cookie banner.
- A WebDriverWait is used with explicit waits to handle elements that load asynchronously, making the tests more stable.
- The tests are designed to handle scenarios such as missing required locations, selecting specific route preferences, and verifying error messages.

## Troubleshooting

1. **ChromeDriver Compatibility**: Ensure the version of ChromeDriver matches your version of Chrome.
2. **Timeout Issues**: If elements take longer to appear, adjust the timeout in `WebDriverWait`.
3. **SpecFlow Bindings**: Ensure that feature files are correctly bound to the steps in `JourneyPlannerSteps`.

This setup allows automated end-to-end testing of the TfL journey planner for validating common user workflows, error handling, and preference settings.