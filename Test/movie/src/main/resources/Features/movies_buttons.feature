@movies
Feature: Movies&Buttons

  Background:
    Given I open the website "http://localhost:3000/"

  Scenario: Verify the home screen button navigates to the home page
    Given I enter the movie name "Spider-Man" in the search field
    When I click on the search button
    When I click on the home screen button
    Then I should be redirected to the popular movies

  Scenario: Verify the home page displays 20 popular movies as initial state
    Then I should see 20 movie elements displayed on the home page

  Scenario: verify the search page title exist
    Given I enter the movie name "Spider-Man" in the search field
    When I click on the search button
    Then I should be able to see "Results" title

  Scenario: verify the movie grid exists
    Then movie grid list should be disblayed

  Scenario: verify load button functionality
    When click on "Load more" button 1 time
    Then I should see 40 movie elements displayed on the home page

  Scenario: verify load button functionality by press on it 2 times
    When click on "Load more" button 2 time
    Then I should see 60 movie elements displayed on the home page

  Scenario: verify load button functionality by press on it 3 times
    When click on "Load more" button 2 time
    Then I should see 80 movie elements displayed on the home page

  Scenario: verify movie details card appear by click at any movie