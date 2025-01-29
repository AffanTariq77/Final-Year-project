import { ComponentFixture, TestBed } from '@angular/core/testing';

import { signupcomponent } from './signup.component';

describe('LoginComponent', () => {
  let component: signupcomponent;
  let fixture: ComponentFixture<signupcomponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ signupcomponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(signupcomponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
