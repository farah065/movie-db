package stepDefinition;

import Pages.HomePage;
import io.cucumber.java.After;
import io.cucumber.java.AfterStep;
import io.cucumber.java.Before;
import io.cucumber.java.BeforeStep;
import io.cucumber.java.en.And;
import io.cucumber.java.en.Given;
import io.cucumber.java.en.Then;
import io.cucumber.java.en.When;
import org.junit.Assert;
import org.openqa.selenium.Keys;
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
        String actualMovieName=homePage.firstMovieInTheList().getText();
        Assert.assertTrue(actualMovieName.contains(search));
    }
    @When("I enter the partial movie name {string} in the search field")
    public void insertPartialNameInSearch(String movieName){
        homePage.searchfield().sendKeys(movieName);
    }
    @When("I enter a string of 101 characters in the search field")
    public void insert101CharachtersInsearchField(){
        String input="a".repeat(101);
        homePage.searchfield().sendKeys(input);
    }

    @Then("the search field should only accept the first 100 characters")
    public void assertSearchFieldAccept100ChOnly(){
        String enteredText = homePage.searchfield().getAttribute("value");
        Assert.assertEquals("Assert The search field should only accept the first 100 characters",100,enteredText.length());
    }
    @Then("I should see a message \"No results found\" displayed on the page")
    public void assertNoResultsFound(){
        String expectedMessage= "No results found";
        String actualMessage=homePage.NoResultsFound().getText();
        Assert.assertTrue("assert no result found",actualMessage.contains(expectedMessage));
    }
    @When("Press Enter at search field")
    public void pressEnterAtSearchField(){
        homePage.searchfield().sendKeys(Keys.ENTER);
    }
    @When("I click on the home screen button")
    public void clickOnHomePageButton(){
        homePage.homepageButton().click();
    }

    @BeforeStep
    public void afterstep() throws InterruptedException {
        Thread.sleep(500);
    }
    @After
    public void after() throws InterruptedException {
        Thread.sleep(3000);
        driver.quit();
    }

}
