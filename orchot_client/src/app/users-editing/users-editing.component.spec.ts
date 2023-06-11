import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UsersEditingComponent } from './users-editing.component';

describe('UsersEditingComponent', () => {
  let component: UsersEditingComponent;
  let fixture: ComponentFixture<UsersEditingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UsersEditingComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UsersEditingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

// import { ComponentFixture, TestBed } from '@angular/core/testing';

// import { UsersEditingComponent } from './users-editing.component';

// describe('UsersEditingComponent', () => {
//   let component: UsersEditingComponent;
//   let fixture: ComponentFixture<UsersEditingComponent>;

//   beforeEach(async () => {
//     await TestBed.configureTestingModule({
//       declarations: [ UsersEditingComponent ]
//     })
//     .compileComponents();

//     fixture = TestBed.createComponent(UsersEditingComponent);
//     component = fixture.componentInstance;
//     fixture.detectChanges();
//   });

//   it('should create', () => {
//     expect(component).toBeTruthy();
//   });
// });
