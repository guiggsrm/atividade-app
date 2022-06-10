import { Badge } from 'react-bootstrap'
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faCheck } from '@fortawesome/free-solid-svg-icons'

export default function Logo() {
    return (
        <>
            <Badge pill bg="success">
                <FontAwesomeIcon icon={faCheck} className='logo' />
            </Badge>{' '}
            Pro tasks
        </>
    )
}
