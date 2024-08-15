Feature: Movie Search Functionality

  Scenario: Verify search results are accurate when entering the exact movie name
    Given I open the website "http://localhost:3000/"
    Given I enter the movie name "Spider-Man" in the search field
    When I click on the search button
    Then I should see the movie "Spider-Man" in the search results

  Scenario: Verify search results are accurate when entering a partial movie name
    Given I open the website "http://localhost:3000/"
    When I enter the partial movie name "Titani" in the search field
    And I click on the search button
    Then I should see the movie "Titanic" in the search results

  Scenario: Verify search field limit is 100 characters
    Given I open the website "http://localhost:3000/"
    When I enter a string of 101 characters in the search field
    Then the search field should only accept the first 100 characters

  Scenario: Verify the application displays an appropriate message when no search results are found
    Given I open the website "http://localhost:3000/"
    When I enter the movie name "tinsaaa" in the search field
    And I click on the search button
    Then I should see a message "No results found" displayed on the page

  Scenario: Verify search results are accurate when entering a movie name with different cases
    Given I open the website "http://localhost:3000/"
    When I enter the movie name "sPiDeR-mAn" in the search field
    And I click on the search button
    Then I should see the movie "Spider-Man" in the search results

  Scenario: Verify search results with press enter button
    Given I open the website "http://localhost:3000/"
    Given I enter the movie name "Spider-Man" in the search field
    When Press Enter at search field
    Then I should see the movie "Spider-Man" in the search results