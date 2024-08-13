package Pages;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;

public class HomePage {
    WebDriver driver = null;

    public HomePage(WebDriver driver){
        this.driver=driver;
    }

    public WebElement movieElement(String movieName){
        return driver.findElement(By.xpath("//*[contains(text(),'"+movieName+"')]"));
    }

}
