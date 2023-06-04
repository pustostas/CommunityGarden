//
//  GardenSelectSideBar.swift
//  CommunityGarden
//
//  Created by Станислав Голя on 01.06.2023.
//

import SwiftUI

var secondaryColor: Color =
Color("SecondaryColor")



struct MenuItem: Identifiable {
    
    enum Action {
        case link(AnyView)
        case action(() -> Void)
        case rootChange(Singleton.RootRoute)
    }
    
    var id = NSUUID().uuidString
    var icon: String
    var text: String
    var action: Action
}

var gardenActions: [MenuItem] = [
    MenuItem(icon: "map.circle.fill", text: "Garden map", action: .rootChange(.gardenMap)),
    MenuItem(icon: "arrowshape.turn.up.backward.circle.fill", text: "Back to gardens", action:  .rootChange(.gardens)),
]
var gardenSelect: [MenuItem] = [
    MenuItem(icon: "house.circle.fill", text: "Gardens", action:  .rootChange(.gardens)),
]
var userActions: [MenuItem] = [
    MenuItem(icon: "leaf.circle.fill", text: "My plants", action:  .rootChange(.myPlants)),
    // MenuItem(icon: "message.circle.fill", text: "Chats", action:  .rootChange(.chats)),
    // MenuItem(icon: "calendar.circle.fill", text: "Calendar", action:  .rootChange(.calendar)),
]


var profileActions: [MenuItem] = [
    //MenuItem(icon: "gearshape.circle.fill", text: "Settings", action:  .rootChange(.settings)),
    MenuItem(
        icon: "arrow.uturn.backward.circle.fill", text: "Logout", action: .action({ Singleton.shared.isLoged = false })),
]

struct SideBar: View {
    @StateObject var singleton = Singleton.shared
    @Binding var isSidebarVisible: Bool
    var sideBarWidth = UIScreen.main.bounds.size.width * 0.7
    var bgColor: Color = Color.accentColor
    var isGardenView: Bool
    var body: some View {
        ZStack {
            GeometryReader { _ in
                EmptyView()
            }
            .background(.black.opacity(0.6))
            .opacity(isSidebarVisible ? 1 : 0)
            .animation(.easeInOut.delay(0.2), value: isSidebarVisible)
            .onTapGesture {
                isSidebarVisible.toggle()
            }
            
            content
        }
        .edgesIgnoringSafeArea(.all)
    }
    
    var content: some View {
        HStack(alignment: .top) {
            ZStack(alignment: .top) {
                secondaryColor
                MenuChevron
                
                VStack(alignment: .leading, spacing: 20) {
                    userProfile
                    Divider()
                    MenuLinks(items: userActions)
                    if(isGardenView == false){
                        Divider()
                        MenuLinks(items: gardenActions)
                    }else{
                        MenuLinks(items: gardenSelect)
                    }
                    Divider()
                    MenuLinks(items: profileActions)
                }
                .padding(.top, 80)
                .padding(.horizontal, 40)
            }
            .frame(width: sideBarWidth)
            .offset(x: isSidebarVisible ? 0 : -sideBarWidth)
            .animation(.default, value: isSidebarVisible)
            
            Spacer()
        }
    }
    
    var MenuChevron: some View {
        ZStack {
            RoundedRectangle(cornerRadius: 18)
                .fill(bgColor)
                .frame(width: 60, height: 60)
                .rotationEffect(Angle(degrees: 45))
                .offset(x: isSidebarVisible ? -18 : -10)
                .onTapGesture {
                    isSidebarVisible.toggle()
                }
            
            Image(systemName: "chevron.right")
                .foregroundColor(.white)
                .rotationEffect(isSidebarVisible ?
                                Angle(degrees: 180) : Angle(degrees: 0))
                .offset(x: isSidebarVisible ? -4 : 8)
                .foregroundColor(.blue)
        }
        .offset(x: sideBarWidth / 2, y: 80)
        .animation(.default, value: isSidebarVisible)
    }
    
    var userProfile: some View {
        VStack(alignment: .leading) {
            HStack {
                NavigationLink(destination: UserView(user: singleton.me!)){
                    
                    AsyncImage(
                        url: singleton.me?.profilePicture ) { image in
                            image
                                .resizable()
                                .frame(width: 50,
                                       height: 50,
                                       alignment: .center)
                                .clipShape(Circle())
                                .overlay {
                                    Circle().stroke(.blue, lineWidth: 2)
                                }
                        } placeholder: {
                            ProgressView()
                        }
                        .aspectRatio(3 / 2, contentMode: .fill)
                        .shadow(radius: 4)
                        .padding(.trailing, 18)
                }
                
                VStack(alignment: .leading, spacing: 6) {
                    Text((singleton.me?.firstName ?? "JOHN") + " " + (singleton.me?.secondName ?? "Doe"))
                        .foregroundColor(.white)
                        .bold()
                        .font(.title3)
                }
            }
            .padding(.bottom, 20)
        }
    }
}

struct MenuLinks: View {
    var items: [MenuItem]
    var body: some View {
        VStack(alignment: .leading, spacing: 30) {
            ForEach(items) { item in
                menuLink(icon: item.icon, text: item.text, action: item.action)
            }
        }
        .padding(.vertical, 14)
        .padding(.leading, 8)
    }
}
extension View {
    /// Applies the given transform if the given condition evaluates to `true`.
    /// - Parameters:
    ///   - condition: The condition to evaluate.
    ///   - transform: The transform to apply to the source `View`.
    /// - Returns: Either the original `View` or the modified `View` if the condition is `true`.
    @ViewBuilder func `if`<Content: View>(_ condition: Bool, transform: (Self) -> Content) -> some View {
        if condition {
            transform(self)
        } else {
            self
        }
    }
}
struct menuLink: View {
    @ObservedObject var singleton = Singleton.shared
    var icon: String
    var text: String
    var action: MenuItem.Action
    @State var activeLink = false
    
    var body: some View {
        
        HStack {
            Image(systemName: icon)
                .resizable()
                .frame(width: 40, height: 40)
                .foregroundColor(.white)
                .padding(.trailing, 18)
            Text(text)
                .foregroundColor(.white)
                .font(.title2)
        }.onTapGesture(count: 1) {
            switch action {
            case let .rootChange(newRoot):
                if(newRoot == .gardens){
                    Singleton.shared.myGarden = nil
                }
                Singleton.shared.rootRoute = newRoot
            case let .action(act):
                act()
            case .link(_):
                activeLink = true
            }
        }
        if case let .link(link) = action {
            NavigationLink(destination: link, isActive: $activeLink) {EmptyView()}
        }
        
    }
    
}




