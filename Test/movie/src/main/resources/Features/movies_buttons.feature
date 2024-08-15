@movies
Feature: Movies&Buttons
  Background:
    Given I open the website "http://localhost:3000/"

    Scenario:
      Given I enter the movie name "Spider-Man" in the search field
      When I click on the search button
      When I click on the home screen button
      Then I should be redirected to the popular movies