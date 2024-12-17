using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppRegra.Models;
using WebAppRegra.Services;

namespace WebAppRegra.Controllers
{
    public class ContactsController : Controller
    {
        private readonly AppDbContext _context;
       
        public ContactsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            try
            {
                var contacts = _context.Contacts.ToList();

                return View(contacts);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    Message = ex.Message
                });
            }
        }

        [HttpGet]
        public IActionResult CreateContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateContact(ContactViewModel contactDTO)
        {
            try
            {
                if (contactDTO == null)
                {
                    return BadRequest("Dados do contato são obrigatórios.");
                }

                if (string.IsNullOrWhiteSpace(contactDTO.Name))
                {
                    ModelState.AddModelError("Name", "Insira um nome.");
                    return View(contactDTO);
                }

                if ( string.IsNullOrWhiteSpace(contactDTO.PhoneNumberType.ToString()))
                {
                    ModelState.AddModelError("PhoneNumber", "Insira um número.");
                    return View(contactDTO);
                }

                var contact = new ContactsModel
                {
                    Name = contactDTO.Name,
                    PhoneNumbers = new List<PhoneNumbersModel>
                    {
                        new()
                        {
                            Number = contactDTO.PhoneNumber.ToString(),
                            Type = contactDTO.PhoneNumberType.ToString()
                        }
                    }
                };

                _context.Contacts.Add(contact);
                _context.SaveChanges();

                return RedirectToAction("EditContact", new { id = contact.Id });
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    Message = ex.Message
                });
            }
        }


        [HttpGet]
        public IActionResult EditContact(int? id)
        {
            try
            {
                if (id == null || id == 0)
                {
                    return BadRequest("Precisa de um id de contato válido");
                }

                ContactsModel contact = _context.Contacts.FirstOrDefault(c => c.Id == id);

                if (contact == null)
                {
                    return NotFound("Nenhum contato foi encontrado.");
                }

                List<PhoneNumbersModel> phoneNumbers = _context.PhoneNumbers
                    .Where(pn => pn.ContactId == id)
                    .ToList();

                var contactViewModel = new ContactViewModel
                {
                    Name = contact.Name,
                    ContactId = contact.Id,
                    PhoneNumbers = phoneNumbers
                };

                return View(contactViewModel);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    Message = ex.Message
                });
            }
        }


        [HttpPost]
        public IActionResult EditContactName(ContactViewModel contactDTO)
        {
            try
            {
                if (contactDTO == null)
                {
                    return BadRequest("Contato inválido.");
                }

                ContactsModel contact = _context.Contacts.FirstOrDefault(c => c.Id == contactDTO.ContactId);

                if (contact == null)
                {
                    return NotFound("Contato não encontrado.");
                }

                contact.Name = contactDTO.Name;

                _context.Contacts.Update(contact);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return View("Error", new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    Message = ex.Message
                });
            }
        }


        [HttpPost]
        public IActionResult AddPhoneNumber(ContactViewModel phoneNumberDTO)
        {
            try
            {
                if (phoneNumberDTO == null)
                {
                    return BadRequest("Número de telefone inválido");
                }

                var contact = _context.Contacts.FirstOrDefault(c => c.Id == phoneNumberDTO.ContactId);

                if (contact == null)
                {
                    
                    return NotFound("Contato não existe.");
                }

                var phoneNumber = new PhoneNumbersModel
                {
                    Number = phoneNumberDTO.PhoneNumber?.ToString(),
                    Type = phoneNumberDTO.PhoneNumberType?.ToString(),
                    ContactId = phoneNumberDTO.ContactId
                };

                if (string.IsNullOrWhiteSpace(phoneNumber.Number) || string.IsNullOrWhiteSpace(phoneNumber.Type))
                {
                    return BadRequest("Você deve preencher o número de telefone e o tipo do número.");
                }

                _context.PhoneNumbers.Add(phoneNumber);
                _context.SaveChanges();

                return RedirectToAction("EditContact", new { id = phoneNumberDTO.ContactId });
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, 
                    Message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult DeleteContact(int? id)
        {
            try
            {
                if (id == null || id == 0)
                {
                    return NotFound("Contato não encontrado");
                }

                ContactsModel contact = _context.Contacts.FirstOrDefault(c => c.Id == id);

                if (contact == null)
                {
                    return NotFound("Contato não encontrado");
                }

                return View(contact);

            } catch (Exception ex)
            {
                return View("Error", new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    Message = ex.Message
                });
            }
            
        }

        [HttpPost]
        public IActionResult DeleteContact(ContactsModel contact)
        {
            try
            {
                if (contact == null || contact.Id == 0)
                {
                    return BadRequest("Contato inválido.");
                }

                var existingContact = _context.Contacts.FirstOrDefault(c => c.Id == contact.Id);

                if (existingContact == null)
                {
                    return NotFound("Contato não encontrado");
                }

                _context.Contacts.Remove(existingContact);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return View("Error", new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    Message = ex.Message
                });
            }
        }

        [HttpGet]
        public IActionResult DeletePhoneNumber(int? id)
        {
            try
            {
                if (id == null || id == 0)
                {
                    return NotFound("Número de Telefone não encontrado");
                }

                PhoneNumbersModel phoneNumber = _context.PhoneNumbers.FirstOrDefault(pn => pn.Id == id);

                if (phoneNumber == null)
                {
                    return NotFound("Número de Telefone não encontrado");
                }

                return View(phoneNumber);
            } catch(Exception ex)
            {
                return View("Error", new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    Message = ex.Message
                });
            }
            
        }

        [HttpPost]
        public IActionResult DeletePhoneNumber(PhoneNumbersModel phoneNumber)
        {
            try
            {
                var phoneNumberInDb = _context.PhoneNumbers.FirstOrDefault(pn => pn.Id == phoneNumber.Id);

                if (phoneNumberInDb == null)
                {
                    return NotFound("Número de telefone não encontrado.");
                }

                _context.PhoneNumbers.Remove(phoneNumberInDb);
                _context.SaveChanges();

                return RedirectToAction("EditContact", new { id = phoneNumberInDb.ContactId });
            } catch(Exception ex)
            {
                return View("Error", new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    Message = ex.Message
                });
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
