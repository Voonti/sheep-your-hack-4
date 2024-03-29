import { Outlet } from 'react-router-dom'

import { Container } from '@chakra-ui/react'

import { LayoutComponent } from './Layout.types'

const Layout: LayoutComponent = () => {
  return (
    <Container maxWidth={{ base: 'full', sm: 'xl', lg: '2xl', xl: '4xl' }}>
      <Outlet />
    </Container>
  )
}

export default Layout
