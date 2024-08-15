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

//    public WebElement movieElement(String movieName){
//        return driver.findElement(By.xpath("//*[contains(text(),'"+movieName+"')]"));
//    }

}
