import { Fcamara.SpaPage } from './app.po';

describe('fcamara.spa App', () => {
  let page: Fcamara.SpaPage;

  beforeEach(() => {
    page = new Fcamara.SpaPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Welcome to app!');
  });
});
