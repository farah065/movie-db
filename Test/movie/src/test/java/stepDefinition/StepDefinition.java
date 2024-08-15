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
import org.openqa.selenium.By;
import org.openqa.selenium.Keys;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.edge.EdgeDriver;

import java.time.Duration;
import java.util.List;

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
        Assert.assertTrue("Assert the first movie in the search",actualMovieName.contains(search));
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
    @Then("I should be redirected to the popular movies")
    public void checkRedirectionToPopularMovies(){
        String expectedTitle="Popular Movies";
        String actualTitle=homePage.homepageTitle().getText();
        Assert.assertTrue("Assertion redirection to home page",actualTitle.contains(expectedTitle));
    }
    @Then("I should see {int} movie elements displayed on the home page")
    public void checkNumberOfMoviesDisplayedAtHomePage(int expectedSize){
        List<WebElement> elements = driver.findElements(By.id("movie-title"));
        int actualSize=elements.size();
        Assert.assertEquals("Assert 20 movies displayed in home page",expectedSize,actualSize);
    }

    @Then("I should be able to see {string} title")
    public void checkSearchPageTitle(String searchTitle){
        String expectedTitle="Results";
        Assert.assertTrue("Assert result page title",searchTitle.contains(expectedTitle));
    }
    @Then("movie grid list should be disblayed")
    public void checkMovieGridDisplay(){
        Assert.assertTrue("Assert movie grid is displayed",homePage.movieGrid().isDisplayed());
    }

    @When("click on \"Load more\" button {int} time")
    public void clickOnLoadMoreButton(int number) throws InterruptedException {
        for(int i=0;i<number;i++) {
            homePage.loadMoreButton().click();
            Thread.sleep(1000);
        }
    }
    @When("Click on the first move at home page")
    public void clickOnFirstMovie(){
        homePage.firstMovieInTheList().click();
    }
    @Then("Description card appear")
    public void checkDescriptionCard(){
        Assert.assertTrue("Assert description card is displayed",homePage.DescriptinCardElement().isDisplayed());
    }

    @BeforeStep
    public void afterstep() throws InterruptedException {
        Thread.sleep(500);
    }
    @After
    public void after() throws InterruptedException {
        Thread.sleep(500);
        driver.quit();
    }

}
