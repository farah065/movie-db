package Pages;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

public class HomePage {
    WebDriver driver = null;

    public HomePage(WebDriver driver){
        this.driver=driver;
    }

    public WebElement searchfield(){
        return driver.findElement(By.id("search-field"));
    }
    public WebElement searchButton(){
        return driver.findElement(By.id("search-icon"));
    }
    public WebElement firstMovieInTheList(){
        return driver.findElement(By.xpath("/html/body/div/div/main/div[2]/div[1]/div/h3"));
    }
    public WebElement NoResultsFound(){
        return driver.findElement(By.xpath("//*[@id=\"no-results\"]/h2/em"));
    }

    public WebElement homepageButton(){
        return driver.findElement(By.cssSelector("#top-bar > img"));
    }
    public WebElement homepageTitle(){
        return driver.findElement(By.cssSelector("#root > div > main > h2"));
    }
    public WebElement movieGrid(){
        return driver.findElement(By.id("movie-grid"));
    }
    public WebElement loadMoreButton(){
        return driver.findElement(By.id("load-more"));
    }


}
