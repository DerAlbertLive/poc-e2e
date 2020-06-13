/// <reference types="cypress" />

context('Window', () => {
    beforeEach(() => {
      cy.visit('/')
    })
  
    it('should add an albert', () => {
        cy.get('#firstName').type('Albert');
        cy.get('#lastName').type('Weinert');
        cy.get('#street').type('Drosselweg');
        cy.get('#city').type('Köln');
        cy.get('form > button').click();

        cy.get('tbody > :last-child > :nth-child(1)').contains('Albert');
        cy.get('tbody > :last-child > :nth-child(2)').contains('Weinert');
        cy.get('tbody > :last-child > :nth-child(3)').contains('Drosselweg');
        cy.get('tbody > :last-child > :nth-child(4)').contains('Köln');
    })
  })
  