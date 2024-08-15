package stepDefinition;

import Pages.HomePage;
import io.cucumber.java.Before;
import io.cucumber.java.en.And;
import io.cucumber.java.en.Given;
import io.cucumber.java.en.Then;
import io.cucumber.java.en.When;
import org.junit.Assert;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.edge.EdgeDriver;

import java.time.Duration;

public class StepDefinition {

    WebDriver driver = new EdgeDriver();
    HomePage homePage = new HomePage(driver);

    @Before
    public void beforeScenarios() {
        driver.manage().window().maximize();
        driver.manage().timeouts().implicitlyWait(Duration.ofSeconds(5));
    }

    @Given("I open the website {string}")
    public void openWebsiteLink(String url){
        driver.get(url);
    }
    @Given("I enter the movie name {string} in the search field")
    public void insertNameInSearch(String movieName){
        homePage.searchfield().sendKeys(movieName);
    }

    @When("I click on the search button")
    public void clickSearchButton(){
        homePage.searchButton().click();
    }

    @Then("I should see the movie {string} in the search results")
    public void checkFirstMovieNameInSearchResults(String search){
        String expectedMovieName=search;
        String actualMovieName=homePage.firstMovieInTheList().getText();
        Assert.assertTrue(actualMovieName.contains(expectedMovieName));
    }

}
