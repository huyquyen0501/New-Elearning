import { ElearningWebsiteTemplatePage } from './app.po';

describe('ElearningWebsite App', function() {
  let page: ElearningWebsiteTemplatePage;

  beforeEach(() => {
    page = new ElearningWebsiteTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
