import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TermsAndServiceComponent } from './terms-and-service.component';

describe('TermsAndServiceComponent', () => {
  let component: TermsAndServiceComponent;
  let fixture: ComponentFixture<TermsAndServiceComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [TermsAndServiceComponent]
    });
    fixture = TestBed.createComponent(TermsAndServiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
