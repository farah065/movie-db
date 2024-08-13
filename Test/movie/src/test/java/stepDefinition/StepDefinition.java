package stepDefinition;

import Pages.HomePage;
import io.cucumber.java.Before;
import io.cucumber.java.en.Given;
import io.cucumber.java.en.When;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.edge.EdgeDriver;

public class StepDefinition {

    WebDriver driver=new EdgeDriver();
    HomePage homePage=new HomePage(driver);
@Before
public void beforeScenarios(){
    driver.manage().window().maximize();
}


//@Given("open the website {string}")
//    public void openWebsite(String url){
//        driver.get(url);
//}
//@When("click on {string}")
//    public void clickOnMovie(String movieName){
//    homePage.movieElement(movieName).click();
//}

}
