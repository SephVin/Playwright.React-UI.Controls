# Playwright.ReactUI.Controls.Extensions

Библиотека предоставляет набор расширений к **Playwright.ReactUI.Controls**

### Как использовать  

**Примеры для компонента [Input](https://tech.skbkontur.ru/kontur-ui/?path=/docs/react-ui_input-data-input--docs):**  

+ `await input.AppendTextAsync("newValue").ConfigureAwait(false);` - добавление значения `newValue` к уже существующему в Input  
+ `await input.WaitToBeVisibleAsync().ConfigureAwait(false);` - ожидание видимости компонента на странице  
+ `await input.WaitToHaveValueAsync("TODO").ConfigureAwait(false);` - ожидание значения `TODO` в Input'e  


# Минимальные требования

+ netstandard2.0 / NET6
+ Playwright 1.51.0
+ @skbkontur/react-ui 4.25.2 (рекомендуется использовать последние версии)