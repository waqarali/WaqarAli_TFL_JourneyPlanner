Feature: Journey Planner Widget

  Scenario: Plan a valid journey from Leicester Square to Covent Garden
    Given I navigate to the TfL homepage
    When I enter "Leicester Square" in the from location
    And I select "Leicester Square Underground Station" from suggestions
    And I enter "Covent Garden" in the to location
    And I select "Covent Garden Underground Station" from suggestions
    And I click Plan my journey
    Then I should see the walking and cycling time results

  Scenario: Edit preferences for least walking routes
    Given I have planned a journey from "Leicester Square" to "Covent Garden"
    When I click Edit preferences
    And I select Routes with least walking
    And I click Update journey
    Then I should see the updated journey time

  Scenario: View details for Covent Garden station
    Given I have planned a journey from "Leicester Square" to "Covent Garden"
    Given I have Updated preferences
    When I click View Details
    Then I should see complete access information for "Covent Garden Underground Station"

  Scenario: Attempt to plan a journey with invalid locations
    Given I navigate to the TfL homepage
    When I enter "Invalid Station" in the from location
    And I enter "Another Invalid Station" in the to location
    And I click Plan my journey
    Then I should see an error message indicating no results found

  Scenario: Attempt to plan a journey with no locations
    Given I navigate to the TfL homepage
    When I do not enter any locations
    And I click Plan my journey
    Then I should see an error message indicating that locations are required